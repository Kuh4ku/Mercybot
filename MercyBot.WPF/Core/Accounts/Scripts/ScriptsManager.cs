using MercyBot.Core.Accounts.Scripts.Actions.Map;
using MoonSharp.Interpreter;
using System;
using MercyBot.Core.Accounts.Scripts.Managers;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using MercyBot.Core.Accounts.Scripts.Actions.Gather;
using MercyBot.Core.Accounts.Scripts.Actions.Fight;
using MercyBot.Core.Accounts.Scripts.Actions.Npcs;
using MercyBot.Core.Accounts.Scripts.Actions.Storage;
using MercyBot.Core.Accounts.Scripts.Actions.Global;
using MercyBot.Core.Accounts.Scripts.Api;
using MercyBot.Core.Accounts.Scripts.Flags;
using System.Linq;
using System.Runtime.CompilerServices;
using MercyBot.Core.Accounts.Scripts.Actions;
using MercyBot.Protocol.Enums;
using MercyBot.Protocol.Messages;
using MercyBot.Core.Extensions;
using GalaSoft.MvvmLight;
using MercyBot.Configurations.Language;
using MercyBot.Utility.Extensions;
using MercyBot.Core.Enums;

namespace MercyBot.Core.Accounts.Scripts
{
    public class ScriptsManager : ViewModelBase, IDisposable
    {

        // Fields
        private Account _account;
        private string _currentScriptName;
        private bool _enabled;
        private LuaScriptManager _scriptManager;
        private FunctionTypes _currentFunctionType;
        private List<IFlag> _entryFlags;
        private int _entryFlagsIndex;
        private API _api;


        // Properties
        public ActionsManager ActionsManager { get; private set; }
        public string CurrentScriptName
        {
            get => _currentScriptName;
            set => Set(ref _currentScriptName, value);
        }
        public bool Enabled
        {
            get => _enabled;
            set => Set(ref _enabled, value);
        }
        public bool Paused { get; private set; }
        public bool Running => _account?.IsGroupChief == true ? Enabled && !Paused : _account?.Group.Chief.Scripts.Running == true;

        public LuaScriptManager ScriptManager => _account.IsGroupChief ? _scriptManager : _account.Group.Chief.Scripts._scriptManager;
        private FunctionTypes CurrentFunctionType
        {
            get => _account.IsGroupChief ? _currentFunctionType : _account.Group.Chief.Scripts._currentFunctionType;
            set
            {
                if (_account.IsGroupChief)
                {
                    _currentFunctionType = value;
                }
                else
                {
                    _account.Group.Chief.Scripts._currentFunctionType = value;
                }
            }
        }


        // Events
        public event Action<string> ScriptLoaded;
        public event Action ScriptStarted;
        public event Action<string> ScriptStopped;


        // Constructor
        public ScriptsManager(Account account)
        {
            _account = account;
            _scriptManager = new LuaScriptManager();
            ActionsManager = new ActionsManager(account);
            _entryFlags = new List<IFlag>();
            _api = new API(_account);

            _account.Game.Fight.FightJoined += Fight_FightJoined;
            _account.Game.Fight.FightEnded += Fight_FightEnded;
            ActionsManager.ActionsFinished += ActionsManager_ActionsFinished;
            ActionsManager.CustomHandled += ActionsManager_CustomHandled;
        }


        public void FromFile(string filePath)
        {
            if (Enabled)
                throw new Exception(LanguageManager.Translate("138"));

            if (!File.Exists(filePath) || !filePath.EndsWith(LanguageManager.Translate("139")))
                throw new Exception(LanguageManager.Translate("140"));

            ScriptManager.LoadFromFile(filePath, BeforeDoFile);
            CurrentScriptName = Path.GetFileNameWithoutExtension(filePath).Truncate(25);

            _account.Logger.LogInfo(LanguageManager.Translate("165"), $"'{Path.GetFileName(filePath)}' Chargé.");
            ScriptLoaded?.Invoke(CurrentScriptName);
        }

        private void BeforeDoFile()
        {
            // Set API
            ScriptManager.SetGlobal("api", _api);

            // We'll set the character and job directly because we don't need coroutines in it
            ScriptManager.SetGlobal("character", _api.Character);
            ScriptManager.SetGlobal("job", _api.Jobs);

            // Set the globals and mount functions directly too
            ScriptManager.SetGlobal("printMessage", new Action<string>((msg) => _account.Logger.LogMessage(LanguageManager.Translate("165"), msg)));
            ScriptManager.SetGlobal("printDebug", new Action<string>((msg) => _account.Logger.LogDebug(LanguageManager.Translate("165"), msg)));
            ScriptManager.SetGlobal("printSuccess", new Action<string>((msg) => _account.Logger.LogInfo(LanguageManager.Translate("165"), msg)));
            ScriptManager.SetGlobal("printError", new Action<string>((msg) => _account.Logger.LogError(LanguageManager.Translate("165"), msg)));
            ScriptManager.SetGlobal("stopScript", new Action(() => StopScript()));
            ScriptManager.SetGlobal("delayFunc", new Action<int>((ms) => ActionsManager.EnqueueAction(new DelayAction(ms), true)));
            ScriptManager.SetGlobal("isFighting", (Func<bool>)_account.IsFighting);
            ScriptManager.SetGlobal("isGathering", (Func<bool>)_account.IsGathering);
            ScriptManager.SetGlobal("isInDialog", (Func<bool>)_account.IsInDialog);
            ScriptManager.SetGlobal("leaveDialogFunc", new Func<bool>(() =>
            {
                if (_account.IsInDialog())
                {
                    ActionsManager.EnqueueAction(new LeaveDialogAction(), true);
                    return true;
                }

                return false;
            }));

            // Inject api script
            ScriptManager.Script.DoString(Properties.Resources.scriptsApiHelper);
        }

        public void StartScript()
        {
            if (string.IsNullOrEmpty(CurrentScriptName))
                return;

            if (Enabled || _account.IsBusy)
                return;

            if (!MercyBotMain.Instance.Server.IsSubscribedToTouch && _account.Game.Character.Level >= 9)
            {
                _account.Logger.LogError(LanguageManager.Translate("165"), LanguageManager.Translate("413"));
                return;
            }

            // If this account is a group chief, do some checkings
            if (_account.HasGroup && _account.IsGroupChief)
            {
                // If a member isn't on the same map
                //if (!_account.Group.IsEveryoneOnTheSameMap())
                //{
                //    _account.Logger.LogError(LanguageManager.Translate("165"), LanguageManager.Translate("394"));
                //    return;
                //}

                if (_account.Group.IsAnyoneBusy())
                {
                    _account.Logger.LogError(LanguageManager.Translate("165"), LanguageManager.Translate("395"));
                    return;
                }
            }

            Enabled = true;
            _account.Logger.LogInfo(LanguageManager.Translate("165"), LanguageManager.Translate("479"));
            ScriptStarted?.Invoke();

            CurrentFunctionType = FunctionTypes.MOVE;
            ProcessScript();
        }

        public void StopScript(string reason = "")
        {
            // In case this account is a member of a group, stop the chief's group
            if (_account.HasGroup && !_account.IsGroupChief && _account.Group.Chief.Scripts.Enabled)
            {
                _account.Group.Chief.Scripts.StopScript(reason);
                return;
            }

            if (!Enabled)
                return;

            Enabled = false;
            Paused = false;
            _entryFlags.Clear();
            _entryFlagsIndex = 0;

            _account.Game.Managers.Cancel();
            ActionsManager.ClearEverything();

            // If this account is a group chief, do the same for members
            if (_account.HasGroup && _account.IsGroupChief)
            {
                _account.Group.MembersCleaningAndClearing();
            }

            if (reason == "")
            {
                _account.Logger.LogInfo(LanguageManager.Translate("165"), LanguageManager.Translate("480"));
            }
            else
            {
                _account.Logger.LogError(LanguageManager.Translate("165"), LanguageManager.Translate("14", reason));
            }

            ScriptStopped?.Invoke(reason);
        }

        private void ProcessScript([CallerMemberName]string CallerMember = "")
            => Task.Run(async () =>
            {
                //_account.Logger.LogDebug("", $"Caller: {CallerMember}, Running: {Running}.");
                if (!Running)
                    return;

                try
                {
                    // If this account is a group chief, do some checkings
                    if (_account.HasGroup && _account.IsGroupChief)
                    {
                        await _account.Group.RegroupMembersIfNeeded();

                        // If a member isn't on the same map
                        //if (!_account.Group.IsEveryoneOnTheSameMap())
                        //{
                        //    StopScript(LanguageManager.Translate("394"));
                        //    return;
                        //}

                        if (_account.Group.IsAnyoneBusy())
                        {
                            StopScript(LanguageManager.Translate("395"));
                            return;
                        }
                    }

                    // If this account is a group's chief, apply a group cheking
                    if (_account.HasGroup && _account.IsGroupChief)
                    {
                        await _account.Group.ApplyCheckings();
                    }
                    // Otherwise apply a solo checking
                    else
                    {
                        await ApplyCheckings();
                    }

                    // In case the script gets stopped after the checkings
                    if (!Running)
                        return;

                    // Handle function
                    var entries = ScriptManager.GetFunctionEntries(CurrentFunctionType.ToString().ToLower());

                    // In case the script doesn't have a function we need
                    if (entries == null)
                    {
                        StopScript(LanguageManager.Translate("143", CurrentFunctionType.ToString().ToLower()));
                        return;
                    }

                    foreach (var entry in entries)
                    {
                        // If the entry doesn't have the map flag (unlikely, but possible)
                        if (entry["map"] == null)
                            continue;

                        // Continue if this isn't the right entry for this map
                        if (!_account.Game.Map.IsOnMap(entry["map"].ToString()))
                            continue;

                        ParseEntry(entry);
                        ProcessCurrentEntryFlag();
                        return;
                    }

                    // In case no entry was found in this map
                    StopScript(LanguageManager.Translate("144") + " 0");
                }
                catch (Exception ex)
                {
                    _account.Logger.LogError(LanguageManager.Translate("165"), ex.ToString());
                    StopScript();
                }
            });

        private void ParseEntry(Table entry)
        {
            _entryFlags.Clear();
            _entryFlagsIndex = 0;
            DynValue flag;

            if (CurrentFunctionType == FunctionTypes.MOVE)
            {
                // gather
                flag = entry.Get("gather");
                if (!flag.IsNil() && flag.Type == DataType.Boolean && flag.Boolean)
                {
                    _entryFlags.Add(new GatherFlag());
                }

                // fight
                flag = entry.Get("fight");
                if (!flag.IsNil() && flag.Type == DataType.Boolean && flag.Boolean)
                {
                    _entryFlags.Add(new FightFlag());
                }
            }

            if (CurrentFunctionType == FunctionTypes.BANK)
            {
                // npcBank
                flag = entry.Get("npcBank");
                if (!flag.IsNil() && flag.Type == DataType.Boolean && flag.Boolean)
                {
                    _entryFlags.Add(new NpcBankFlag());
                }
            }

            if (CurrentFunctionType == FunctionTypes.PHENIX)
            {
                // phenix
                flag = entry.Get("phenix");
                if (!flag.IsNil() && flag.Type == DataType.String && short.TryParse(flag.String, out short phenixCellId))
                {
                    _entryFlags.Add(new PhenixFlag(phenixCellId));
                }
            }

            // custom
            flag = entry.Get("custom");
            if (!flag.IsNil() && flag.Type == DataType.Function)
            {
                _entryFlags.Add(new CustomFlag(flag));
            }

            // door
            flag = entry.Get("door");
            if (!flag.IsNil() && flag.Type == DataType.String && short.TryParse(flag.String, out short doorCellId))
            {
                _entryFlags.Add(new DoorFlag(doorCellId));
            }

            // changeMap
            flag = entry.Get("changeMap");
            if (!flag.IsNil() && flag.Type == DataType.String)
            {
                _entryFlags.Add(new ChangeMapFlag(flag.String));
            }

            // Check if there is at least one valid flag
            if (_entryFlags.Count == 0)
            {
                StopScript(LanguageManager.Translate("144") + " 1");
            }
        }

        private void ProcessEntryFlags(bool avoidChecks = false, [CallerMemberName]string caller = "")
        {
            if (!Running)
                return;

           // _account.Logger.LogDebug("", $"ProcessEntryFlags, caller: {caller}.");

            // Check for max_pods
            if (GotToMaxPods())
            {
                ProcessScript();
                return;
            }

            if (!avoidChecks)
            {
                // If the current flag is gather, check if we can still gather in this map
                switch (_entryFlags[_entryFlagsIndex])
                {
                    case GatherFlag _:
                        var gatherAction = CreateGatherAction();

                        // We'll assume gatherAction can never be null
                        if (_account.Game.Managers.Gathers.CanGather(gatherAction.Elements))
                        {
                            ProcessCurrentEntryFlag(gatherAction);
                            return;
                        }
                        break;
                    case FightFlag _:
                        var fightAction = CreateFightAction();

                        if (_account.Game.Map.CanFight(fightAction.MinMonsters, fightAction.MaxMonsters, fightAction.MinMonstersLevel, fightAction.MaxMonstersLevel,
                            fightAction.ForbiddenMonsters, fightAction.MandatoryMonsters))
                        {
                            ProcessCurrentEntryFlag(fightAction);
                            return;
                        }
                        break;
                }

                // If the current flag is fight, check if we can still fight in this map
            }

            // Otherwise just move to the next flag
            _entryFlagsIndex++;

            // If we processed all the flags
            if (_entryFlagsIndex == _entryFlags.Count)
            {
                // This should never happen, since a door or changeMap would change you the map so it'll re-process the script
                // But if no door or changeMap was found in the entry, stop the script !
                StopScript(LanguageManager.Translate("144") + " 2");
            }
            else
            {
                ProcessCurrentEntryFlag();
            }
        }

        private void ProcessCurrentEntryFlag(ScriptAction alreadyParsedAction = null, [CallerMemberName]string caller = "")
        {
            if (!Running)
                return;

            var currentFlag = _entryFlags[_entryFlagsIndex];
            //_account.Logger.LogDebug("", $"ProcessCurrentEntryFlag, (caller: {caller}, currentFlag: {currentFlag}).");

            switch (currentFlag)
            {
                case GatherFlag _:
                    HandleGatherFlag(alreadyParsedAction as GatherAction);
                    break;
                case FightFlag _:
                    HandleFightFlag(alreadyParsedAction as FightAction);
                    break;
                case NpcBankFlag _:
                    HandleNpcBankFlag();
                    break;
                case PhenixFlag pf:
                    HandlePhenixFlag(pf);
                    break;
                case CustomFlag cf:
                    ActionsManager.HandleCustom(cf.Function);
                    break;
                case DoorFlag df:
                    HandleDoorFlag(df);
                    break;
                case ChangeMapFlag cmf:
                    HandleChangeMapFlag(cmf);
                    break;
            }
        }

        private bool GotToMaxPods()
        {
            int maxPods = ScriptManager.GetGlobalOr(LanguageManager.Translate("145"), DataType.Number, 90);
            return _account.Game.Character.Inventory.WeightPercent >= maxPods;
        }

        #region Checkings

        public async Task ApplyCheckings()
        {
            // Check for death
            await CheckForDeath();

            if (!Running)
                return;

            // Only check for regenration when we're alive and kicking !
            if (_account.Game.Character.LifeStatus == PlayerLifeStatusEnum.STATUS_ALIVE_AND_KICKING)
            {
                // Check for regeneration in the script
                await CheckScriptRegeneration();

                if (!Running)
                    return;

                // Check for regeneration
                await CheckRegeneration();

                if (!Running)
                    return;
            }

            // Check for bags
            await CheckForBags();

            if (!Running)
                return;

            // Check for auto boosting
            await CheckAutoBoosting();

            if (!Running)
                return;

            // Check if the character got to MAX_PODS
            await CheckForMaxPods();

            if (!Running)
                return;

            // Check for auto mount
            await CheckForMount();
        }

        private async Task CheckForDeath()
        {
            // Check first if the character is a tombstone to free it
            if (_account.Game.Character.LifeStatus == PlayerLifeStatusEnum.STATUS_TOMBSTONE)
            {
                _account.Logger.LogInfo(LanguageManager.Translate("165"), LanguageManager.Translate("152"));
                await _account.Network.SendMessageAsync(new GameRolePlayFreeSoulRequestMessage());

                // Wait for a map change since after a free soul, we get teleported
                await _account.Game.Map.WaitMapChange(10);
                await Task.Delay(1000);
            }

            // Check if the character is a phantom (in case the user reconnects as a phantom and not a tombstone)
            if (_account.Game.Character.LifeStatus == PlayerLifeStatusEnum.STATUS_PHANTOM)
            {
                if (!MercyBotMain.Instance.Server.IsSubscribedToTouch)
                {
                    StopScript(LanguageManager.Translate("411"));
                }
                else
                {
                    _account.Logger.LogInfo(LanguageManager.Translate("165"), LanguageManager.Translate("153"));
                    CurrentFunctionType = FunctionTypes.PHENIX;
                }
            }

        }

        private async Task CheckScriptRegeneration()
        {
            // Check if the AUTO_REGEN parameter exists
            var autoRegen = ScriptManager.GetGlobalOr<Table>("AUTO_REGEN", DataType.Table, null);

            if (autoRegen == null || !_account.Configuration.AutoRegenAccepted)
                return;

            int minLife = autoRegen.GetOr("minLife", DataType.Number, 0);
            int maxLife = autoRegen.GetOr("maxLife", DataType.Number, 100);

            // Check if we need to regenerate
            if (minLife == 0 || _account.Game.Character.Stats.LifePercent > minLife)
                return;

            // Calculate how much HP we need back, based on maxLife
            int endHp = maxLife * (int)_account.Game.Character.Stats.MaxLifePoints / 100;
            int hpToRegen = endHp - (int)_account.Game.Character.Stats.LifePoints;

            // Get the items that the user wants us to use for regen
            var items = autoRegen.Get("items").ToObject<List<int>>();

            for (int i = 0; i < items.Count; i++)
            {
                // Hard coded the value 20 because its useless to waste a regen item for this much hp to regen
                if (hpToRegen < 20)
                    break;

                var obj = _account.Game.Character.Inventory.GetObjectByGID(items[i]);

                // If the item doesn't exist, go to the next one
                if (obj == null)
                    continue;

                // If the item is not a regen item, go to the next one
                if (obj.RegenValue <= 0)
                    continue;

                // Get how much qty we need
                int neededQty = (int)Math.Floor(hpToRegen / (double)obj.RegenValue);
                // Then get how much qty we actually have
                int validQty = Math.Min(neededQty, (int)obj.Quantity);

                // Use the object
                _account.Game.Character.Inventory.UseObject(obj, (uint)validQty);
                await Task.Delay(800);

                // Decreate the hp to regen
                hpToRegen -= (int)obj.RegenValue * validQty;
            }
        }

        private async Task CheckRegeneration()
        {
            // This option is disabled if the value is 0
            if (_account.Extensions.Fights.Configuration.RegenStart == 0)
                return;

            // In case some user is...
            if (_account.Extensions.Fights.Configuration.RegenEnd <= _account.Extensions.Fights.Configuration.RegenStart)
                return;

            // Check if we need to regen
            if (_account.Game.Character.Stats.LifePercent <= _account.Extensions.Fights.Configuration.RegenStart)
            {
                // Calculate how much HP we need back, based on the RegenEnd option
                int endHp = _account.Extensions.Fights.Configuration.RegenEnd * (int)_account.Game.Character.Stats.MaxLifePoints / 100;
                int hpToRegen = endHp - (int)_account.Game.Character.Stats.LifePoints;

                if (hpToRegen > 0)
                {
                    int estimatedTime = hpToRegen / 2;

                    // Use sit emote for double hp regen (if we're not already sitting)
                    if (_account.State != AccountStates.REGENERATING)
                    {
                        _account.Game.Character.Sit();
                    }

                    _account.Logger.LogInfo(LanguageManager.Translate("165"), LanguageManager.Translate("150", hpToRegen, estimatedTime));

                    // Then just wait it before continuing
                    for (int i = 0; i < estimatedTime && _account.Game.Character.Stats.LifePercent <= _account.Extensions.Fights.Configuration.RegenEnd && Running; i++)
                    {
                        await Task.Delay(1000);
                    }

                    if (Running)
                    {
                        // Make the character get up when he's done
                        if (_account.State == AccountStates.REGENERATING)
                        {
                            _account.Game.Character.Sit();
                        }

                        _account.Logger.LogInfo(LanguageManager.Translate("165"), LanguageManager.Translate("151"));
                    }
                }
            }
        }

        private async Task CheckForBags()
        {
            if (!MercyBotMain.Instance.Server.IsSubscribedToTouch)
                return;

            if (!ScriptManager.GetGlobalOr(LanguageManager.Translate("154"), DataType.Boolean, false))
                return;

            var bags = _account.Game.Character.Inventory.Objects.Where(o => o.TypeId == 100 && o.SuperTypeId == 6).ToList();

            if (bags.Count > 0)
            {
                for (int i = 0; i < bags.Count; i++)
                {
                    _account.Game.Character.Inventory.UseObject(bags[i]);
                    await Task.Delay(800);
                }

                _account.Logger.LogInfo(LanguageManager.Translate("165"), LanguageManager.Translate("155", bags.Count));
            }
        }

        private async Task CheckAutoBoosting()
        {
            // Stat
            if (_account.Configuration.StatToBoost != BoostableStats.NONE && _account.Game.Character.Stats.StatsPoints > 0)
            {
                if (_account.Game.Character.AutoBoostStat(_account.Configuration.StatToBoost))
                    await Task.Delay(1000);
            }

            // Spells
            if (_account.Configuration.SpellsToBoost.Count > 0 && _account.Game.Character.Stats.SpellsPoints > 0)
            {
                foreach (var spellToBoost in _account.Configuration.SpellsToBoost)
                {
                    if (_account.Game.Character.AutoLevelUpSpell(spellToBoost.Id, spellToBoost.Level))
                        await Task.Delay(1000);
                }
            }
        }

        private async Task CheckForMaxPods()
        {
            // We'll only change the function type if the current one is MOVE
            // This will prevent us from overwriting an ongoing PHENIX session
            if (GotToMaxPods() && CurrentFunctionType == FunctionTypes.MOVE)
            {
                // Check if there is an AUTO_DELETE option
                await CheckForAutoDelete();

                // To fix this bug https://pastebin.com/HWYjTjuE
                // We will check if the script is running (since a fight pauses the script)
                if (!Running)
                    return;

                // If the character is still full
                if (GotToMaxPods())
                {
                    _account.Logger.LogInfo(LanguageManager.Translate("165"), LanguageManager.Translate("146"));
                    CurrentFunctionType = FunctionTypes.BANK;
                }
            }
        }

        private async Task CheckForAutoDelete()
        {
            if (!MercyBotMain.Instance.Server.IsSubscribedToTouch)
                return;

            var autoDeleteElements = ScriptManager.GetGlobalOr<Table>(LanguageManager.Translate("147"), DataType.Table, null);

            // If the script has an AUTO_DELETE configuration
            if (autoDeleteElements != null)
            {
                _account.Logger.LogDebug(LanguageManager.Translate("165"), LanguageManager.Translate("148"));

                foreach (var gid in autoDeleteElements.Values)
                {
                    // Only take numbers
                    if (gid.Type != DataType.Number)
                        continue;

                    // Remove all the objects and not only the first one, because sometimes objects are splitted to 1-s
                    foreach (var obj in _account.Game.Character.Inventory.GetObjectsByGID((int)gid.Number))
                    {
                        _account.Game.Character.Inventory.DeleteObject(obj, 0);
                        await Task.Delay(800);
                    }
                }

                _account.Logger.LogInfo(LanguageManager.Translate("165"), LanguageManager.Translate("149"));
            }
        }

        private async Task CheckForMount()
        {
            if (!_account.Configuration.AutoMount || !_account.Game.Character.Mount.HasMount || _account.Game.Character.Mount.IsRiding)
                return;

            _account.Game.Character.Mount.ToggleRiding();
            _account.Logger.LogInfo("Scripts", LanguageManager.Translate("572"));
            await Task.Delay(1000);
        }

        private bool CheckForSpecialCases([CallerMemberName]string caller = "")
        {
            //_account.Logger.LogDebug("", $"Checking for special cases {caller}.");

            // Special case: When we release the character from being a fantom, we have to go back to the MOVE function.
            // Group special case: only reset the current function when everyone is alive
            if (CurrentFunctionType == FunctionTypes.PHENIX &&
                (_account.HasGroup && _account.IsGroupChief ? _account.Group.IsEveryoneAliveAndKicking() : _account.Game.Character.LifeStatus == PlayerLifeStatusEnum.STATUS_ALIVE_AND_KICKING))
            {
                _account.Logger.LogDebug(LanguageManager.Translate("165"), LanguageManager.Translate("156"));
                CurrentFunctionType = FunctionTypes.MOVE;
                ProcessScript();
                return true;
            }

            // Special case: When its the BANK function and the character is not fullpods anymore
            // Group special case: only reset the current function when everyone is not full pods anymore
            if (CurrentFunctionType == FunctionTypes.BANK && (_account.HasGroup && _account.IsGroupChief ? !_account.Group.IsAnyoneFullWeight() : !GotToMaxPods()))
            {
                _account.Logger.LogDebug(LanguageManager.Translate("165"), LanguageManager.Translate("157"));
                CurrentFunctionType = FunctionTypes.MOVE;
                ProcessScript();
                //_account.Logger.LogDebug("", "On sort");
                return true;
            }

            //_account.Logger.LogDebug("", "No special case 1");
            return false;
        }

        #endregion

        #region Flags Handlers

        private void HandleGatherFlag(GatherAction gatherAction)
        {
            var action = gatherAction ?? CreateGatherAction();

            // If the action is null, its probably due to the character not having ressources to gather (no jobs usually)
            if (action == null)
                return;

            // If we can actually gather in this map, enqueue the action
            if (_account.Game.Managers.Gathers.CanGather(action.Elements))
            {
                ActionsManager.EnqueueAction(action, true);
            }
            // Otherwise move to the next flag
            // We'll avoid the checks because we know we can't gather anymore
            else
            {
                _account.Logger.LogDebug(LanguageManager.Translate("165"), LanguageManager.Translate("530"));
                ProcessEntryFlags(true);
            }
        }

        private GatherAction CreateGatherAction()
        {
            // Check if the script has the elements to gather
            var elementsToGather = ScriptManager.GetGlobalOr<Table>("ELEMENTS_TO_GATHER", DataType.Table, null);
            List<int> ressourcesIds = new List<int>();

            // If yes
            if (elementsToGather != null)
            {
                foreach (var etg in elementsToGather.Values)
                {
                    if (etg.Type != DataType.Number)
                        continue;

                    if (_account.Game.Character.Jobs.HasCollectSkill((int)etg.Number))
                    {
                        ressourcesIds.Add((int)etg.Number);
                    }
                }
            }

            // If the list of ressources is empty (not set in the script)
            if (ressourcesIds.Count == 0)
            {
                ressourcesIds.AddRange(_account.Game.Character.Jobs.GetCollectSkillsIds());
            }

            // In case the character has no jobs or something
            if (ressourcesIds.Count == 0)
            {
                _account.Scripts.StopScript(LanguageManager.Translate("158"));
                return null;
            }

            return new GatherAction(ressourcesIds);
        }

        private void HandleFightFlag(FightAction fightAction)
        {
            var action = fightAction ?? CreateFightAction();

            // If we got to the max fights per map, reprocess entry flags
            int maxFightsPerMap = ScriptManager.GetGlobalOr("MAX_FIGHTS_PER_MAP", DataType.Number, -1);
            if (maxFightsPerMap != -1 && ActionsManager.FightsOnThisMap >= maxFightsPerMap)
            {
                _account.Logger.LogDebug("Scripts", LanguageManager.Translate("556", maxFightsPerMap));
                ProcessEntryFlags(true);
                return;
            }

            // If we can actually fight in this map, enqueue the action
            if (_account.Game.Map.CanFight(action.MinMonsters, action.MaxMonsters, action.MinMonstersLevel, action.MaxMonstersLevel, action.ForbiddenMonsters, action.MandatoryMonsters))
            {
                ActionsManager.EnqueueAction(action, true);
            }
            // Otherwise move to the next flag
            // We'll avoid the checks because we know we can't fight anymore
            else
            {
                _account.Logger.LogDebug(LanguageManager.Translate("165"), LanguageManager.Translate("159"));
                ProcessEntryFlags(true);
            }
        }

        private FightAction CreateFightAction()
        {
            int minMonsters = ScriptManager.GetGlobalOr("MIN_MONSTERS", DataType.Number, 1);
            int maxMonsters = ScriptManager.GetGlobalOr("MAX_MONSTERS", DataType.Number, 8);
            int minLevel = ScriptManager.GetGlobalOr("MIN_MONSTERS_LEVEL", DataType.Number, 1);
            int maxLevel = ScriptManager.GetGlobalOr("MAX_MONSTERS_LEVEL", DataType.Number, 1000);
            var forbiddenMonsters = new List<int>();
            var mandatoryMonsters = new List<int>();

            // Forbidden monsters
            var entry = ScriptManager.GetGlobalOr<Table>("FORBIDDEN_MONSTERS", DataType.Table, null);
            if (entry != null)
            {
                foreach (var fm in entry.Values)
                {
                    if (fm.Type != DataType.Number)
                        continue;

                    forbiddenMonsters.Add((int)fm.Number);
                }
            }

            // Mandatory monsters
            entry = ScriptManager.GetGlobalOr<Table>("MANDATORY_MONSTERS", DataType.Table, null);
            if (entry != null)
            {
                foreach (var mm in entry.Values)
                {
                    if (mm.Type != DataType.Number)
                        continue;

                    mandatoryMonsters.Add((int)mm.Number);
                }
            }

            return new FightAction(minMonsters, maxMonsters, minLevel, maxLevel, forbiddenMonsters, mandatoryMonsters);
        }

        private void HandleNpcBankFlag()
        {
            // Opening the storage
            ActionsManager.EnqueueAction(new NpcBankAction(-1, -1));

            // BANK_PUT_ITEMS
            var bankPutItems = ScriptManager.GetGlobalOr<Table>("BANK_PUT_ITEMS", DataType.Table, null);

            if (bankPutItems != null && bankPutItems.Length > 0)
            {
                foreach (var val in bankPutItems.Values)
                {
                    if (val.Type != DataType.Table)
                        continue;

                    var item = val.Table.Get("item");
                    var quantity = val.Table.Get("quantity");

                    if (item.IsNil() || item.Type != DataType.Number || quantity.IsNil() || quantity.Type != DataType.Number)
                        continue;

                    ActionsManager.EnqueueAction(new StoragePutItemAction((int)item.Number, (uint)quantity.Number));
                }
            }
            // If BANK_PUT_ITEMS is not set, put all items
            else
            {
                ActionsManager.EnqueueAction(new StoragePutAllItemsAction());
            }

            // BANK_GET_ITEMS
            var bankGetItems = ScriptManager.GetGlobalOr<Table>("BANK_GET_ITEMS", DataType.Table, null);

            if (bankGetItems != null)
            {
                foreach (var val in bankGetItems.Values)
                {
                    if (val.Type != DataType.Table)
                        continue;

                    var item = val.Table.Get("item");
                    var quantity = val.Table.Get("quantity");

                    if (item.IsNil() || item.Type != DataType.Number || quantity.IsNil() || quantity.Type != DataType.Number)
                        continue;

                    ActionsManager.EnqueueAction(new StorageGetItemAction((int)item.Number, (uint)quantity.Number));
                }
            }

            // AUTO_REGEN store
            var autoRegen = ScriptManager.GetGlobalOr<Table>("AUTO_REGEN", DataType.Table, null);
            if (autoRegen != null)
            {
                int store = autoRegen.GetOr("store", DataType.Number, 0);
                if (store > 0)
                {
                    ActionsManager.EnqueueAction(new StorageGetAutoRegenStoreAction(autoRegen.Get("items").ToObject<List<int>>(), store));
                }
            }

            // BANK_PUT_KAMAS
            int amount = ScriptManager.GetGlobalOr("BANK_PUT_KAMAS", DataType.Number, -1);
            if (amount >= 0)
            {
                ActionsManager.EnqueueAction(new StoragePutKamasAction(amount));
            }

            // BANK_GET_KAMAS
            amount = ScriptManager.GetGlobalOr("BANK_GET_KAMAS", DataType.Number, -1);
            if (amount >= 0)
            {
                ActionsManager.EnqueueAction(new StorageGetKamasAction(amount));
            }

            // Leave the storage
            ActionsManager.EnqueueAction(new LeaveDialogAction(), true);
        }

        private void HandlePhenixFlag(PhenixFlag flag)
        {
            var phenix = _account.Game.Map.Phenixs.FirstOrDefault(ph => ph.CellId == flag.CellId);

            // If the phenix wasn't found
            if (phenix == null)
            {
                StopScript(LanguageManager.Translate("160", flag.CellId));
                return;
            }

            ActionsManager.EnqueueAction(new UseAction(flag.CellId, -1));
            ActionsManager.EnqueueAction(new DelayAction(2000), true);
        }

        private void HandleDoorFlag(DoorFlag flag)
        {
            var door = _account.Game.Map.Doors.FirstOrDefault(d => d.CellId == flag.CellId);

            if (door == null)
            {
                StopScript(LanguageManager.Translate("161", flag.CellId));
                return;
            }

            ActionsManager.EnqueueAction(new UseAction(flag.CellId, -1));
            ActionsManager.EnqueueAction(new WaitMapChangeAction(10000), true);
        }

        private void HandleChangeMapFlag(ChangeMapFlag cmf)
        {
            if (ChangeMapAction.TryParse(cmf.Where, out ChangeMapAction action))
            {
                ActionsManager.EnqueueAction(action, true);
            }
            else
            {
                StopScript(LanguageManager.Translate("162"));
            }
        }

        #endregion

        #region Received Events

        private void Fight_FightJoined()
        {
            if (!Enabled)
                return;

            Paused = true;
            _account.Game.Managers.Gathers.CancelGather();
            _account.Game.Managers.Interactives.CancelUse();
            _account.Logger.LogDebug(LanguageManager.Translate("165"), LanguageManager.Translate("163"));
        }

        private void Fight_FightEnded()
        {
            if (!Enabled)
                return;

            Paused = false;
            _account.Logger.LogDebug(LanguageManager.Translate("165"), LanguageManager.Translate("164"));
        }

        private void ActionsManager_ActionsFinished(Account account, bool mapChanged)
        {
            // If this account is a member of a group
            if (_account.HasGroup)
            {
                // If this account is not the chief, ignore this event since the Group will handle it
                if (!_account.IsGroupChief)
                {
                    Console.WriteLine("{0} - ActionFinished ignored.", _account.AccountConfig.Username);
                    return;
                }

                // Otherwise wait for all the ActionsFinished events from the members
                _account.Logger.LogDebug("Groups", "Waiting the ActionsFinished for members.");
                _account.Group.WaitForAllActionsFinished();
                _account.Logger.LogDebug("Groups", "All the actions of the members are done.");
            }

            // Check for special cases (full pods, phenix)
            if (CheckForSpecialCases())
                return;

            // If a map changed occured, re-process the script
            if (mapChanged)
                ProcessScript();
            else
                // If no special case was found, process entry flags
                ProcessEntryFlags();
        }

        private void ActionsManager_CustomHandled(Account account, bool mapChanged)
        {
            // If this account is a member of a group, ignore this event because Group will handle it
            if (_account.HasGroup && !_account.IsGroupChief)
                return;

            // Check for special cases (full pods, phenix)
            if (CheckForSpecialCases())
                return;

            // If a map changed occured, re-process the script
            if (mapChanged)
                ProcessScript();
            else
                // If no special case was found, process entry flags
                ProcessEntryFlags();
        }

        #endregion

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _scriptManager.Dispose();
                    _api.Dispose();
                    ActionsManager.Dispose();
                }

                _entryFlags.Clear();
                _entryFlags = null;
                _scriptManager = null;
                _api = null;
                ActionsManager = null;
                Enabled = false;
                Paused = false;
                CurrentScriptName = null;

                _account = null;

                _disposedValue = true;
            }
        }

        ~ScriptsManager() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}