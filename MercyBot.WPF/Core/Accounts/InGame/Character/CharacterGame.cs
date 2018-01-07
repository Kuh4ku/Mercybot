using GalaSoft.MvvmLight;
using MercyBot.Core.Accounts.InGame.Character.Inventory;
using MercyBot.Core.Accounts.InGame.Character.Jobs;
using MercyBot.Core.Accounts.InGame.Character.Mount;
using MercyBot.Core.Enums;
using MercyBot.Core.Extensions;
using MercyBot.Protocol.Data;
using MercyBot.Protocol.Enums;
using MercyBot.Protocol.Messages;
using MercyBot.Protocol.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Accounts.InGame.Character
{
    public class CharacterGame : ViewModelBase, IClearable, IDisposable
    {

        // Fields
        private Account _account;
        private Timer _regenTimer;
        private Breeds _breedData;
        private bool _isSelected;
        private string _name;
        private byte _level;
        private string _skinUrl;
        private PlayerStatusEnum _status;


        // Properties
        public bool IsSelected
        {
            get => _isSelected;
            private set => Set(ref _isSelected, value);
        }
        public uint Id { get; private set; }
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
        public byte Level
        {
            get => _level;
            set
            {
                Set(ref _level, value);
                if (!MercyBotMain.Instance.Server.IsSubscribedToTouch && Level >= 9)
                {
                    _account.Scripts.StopScript(LanguageManager.Translate("413"));
                }
            }
        }
        public bool Sex { get; private set; }
        public BreedEnum Breed { get; private set; }
        public EntityLook Look { get; private set; }
        public string SkinUrl
        {
            get => _skinUrl;
            set => Set(ref _skinUrl, value);
        }
        public CharacterStats Stats { get; private set; }
        public PlayerLifeStatusEnum LifeStatus { get; private set; }
        public PlayerStatusEnum Status
        {
            get => _status;
            set => Set(ref _status, value);
        }
        public InventoryGame Inventory { get; private set; }
        public ObservableCollection<SpellEntry> Spells { get; private set; }
        public JobsGame Jobs { get; private set; }
        public MountGame Mount { get; private set; }


        // Events
        public event Action CharacterSelected;
        public event Action StatsUpdated;
        public event Action SpellsUpdated;


        // Constructor
        public CharacterGame(Account account)
        {
            _account = account;
            _regenTimer = new Timer(RegenTimerCallback, null, Timeout.Infinite, Timeout.Infinite);

            Stats = new CharacterStats();
            Inventory = new InventoryGame(account);
            Spells = new ObservableCollection<SpellEntry>();
            Jobs = new JobsGame(account);
            Mount = new MountGame(account);
        }


        public bool FreeSoul()
        {
            if (LifeStatus != PlayerLifeStatusEnum.STATUS_TOMBSTONE)
                return false;
            
            return true;
        }

        public void Sit()
        {
            if (_account.IsBusy)
                return;

            _account.Network.SendMessage(new EmotePlayRequestMessage(1));
        }

        public SpellEntry GetSpell(int id)
            => Spells.FirstOrDefault(f => f.Id == id);

        public SpellEntry GetSpellByName(string name)
            => Spells.FirstOrDefault(f => f.Name == name);

        public bool CanBoostStat(BoostableStats stat)
            => Stats.StatsPoints >= GetNeededPointsToBoostStat(stat);

        public bool BoostStat(BoostableStats stat, uint pts = 1)
        {
            uint neededPts = GetNeededPointsToBoostStat(stat);

            if (Stats.StatsPoints < neededPts)
                return false;

            uint possiblePts = Stats.StatsPoints / neededPts;

            pts = (pts == 0 ?
                  possiblePts :
                  pts > possiblePts ? possiblePts : pts) * neededPts;

            _account.Network.SendMessage(new StatsUpgradeRequestMessage((uint)stat, pts));
            _account.Logger.LogInfo(LanguageManager.Translate("107"), LanguageManager.Translate("108", pts, stat.ToFriendlyString()));
            return true;
        }

        public bool AutoBoostStat(BoostableStats stat)
        {
            if (Stats.StatsPoints == 0)
                return false;

            List<List<int>> data = null;
            int baseStats = 0;
            uint statsPointsLeft = Stats.StatsPoints;
            uint pts = 0;

            switch (stat)
            {
                case BoostableStats.AGILITY:
                    data = _breedData.StatsPointsForAgility;
                    baseStats = Stats.Agility.Base;
                    break;
                case BoostableStats.CHANCE:
                    data = _breedData.StatsPointsForChance;
                    baseStats = Stats.Chance.Base;
                    break;
                case BoostableStats.INTELLIGENCE:
                    data = _breedData.StatsPointsForIntelligence;
                    baseStats = Stats.Intelligence.Base;
                    break;
                case BoostableStats.STRENTH:
                    data = _breedData.StatsPointsForStrength;
                    baseStats = Stats.Strength.Base;
                    break;
                case BoostableStats.VITALITY:
                    data = _breedData.StatsPointsForVitality;
                    baseStats = Stats.Vitality.Base;
                    break;
                case BoostableStats.WISDOM:
                    data = _breedData.StatsPointsForWisdom;
                    baseStats = Stats.Wisdom.Base;
                    break;
            }

            //baseStats = 90;
            //statsPointsLeft = 20;

            while (statsPointsLeft > 0)
            {
                uint neededPts = (uint)data.FindLast(d => baseStats >= d[0])[1];

                if (baseStats >= 50)
                {

                }

                if (statsPointsLeft < neededPts)
                    break;

                statsPointsLeft -= neededPts;
                pts += neededPts;
                baseStats++;
            }

            if (pts == 0)
                return false;

            _account.Network.SendMessage(new StatsUpgradeRequestMessage((uint)stat, pts));
            _account.Logger.LogInfo(LanguageManager.Translate("107"), LanguageManager.Translate("108", pts, stat.ToFriendlyString()));
            return true;
        }

        public bool LevelUpSpell(SpellEntry spell)
        {
            // If the spell is the basic attack or is already at max level
            if (spell.Id == 0 || spell.Level == 6)
                return false;

            // Check if the character has enough spell points
            if (_account.Game.Character.Stats.SpellsPoints < spell.Level)
                return false;

            // If the character doesn't have the required level for a level 6 spell
            if (spell.Level == 5 && Level < spell.MinPlayerLevel + 100)
                return false;

            _account.Network.SendMessage(new SpellUpgradeRequestMessage((uint)spell.Id, (uint)spell.Level + 1));
            _account.Logger.LogInfo(LanguageManager.Translate("107"), LanguageManager.Translate("374", spell.Name, spell.Level + 1));
            return true;
        }

        public bool AutoLevelUpSpell(int spellId, int maxLevel = 6)
        {
            // In case its the basic attack or we don't have any spell points
            if (spellId == 0 || Stats.SpellsPoints == 0)
                return false;

            var spell = GetSpell(spellId);

            // In case the character doesn't have the spell or the spell is already maxed out
            if (spell == null || spell.Level == 6)
                return false;

            // If the character can't reach the max level
            if (maxLevel == 6 && Level < spell.MinPlayerLevel + 100)
                maxLevel--;

            // If we already reached the max level
            if (spell.Level >= maxLevel)
                return false;

            uint spellsPtsLeft = Stats.SpellsPoints;
            byte spellLevel = spell.Level;
            uint level = 0;

            while (spellsPtsLeft > 0 && spellLevel < maxLevel && spellLevel < 6)
            {
                if (spellsPtsLeft < spellLevel)
                    break;

                spellsPtsLeft -= spellLevel;
                spellLevel++;
                level = spellLevel;
            }

            if (level == 0)
                return false;


            _account.Network.SendMessage(new SpellUpgradeRequestMessage((uint)spellId, level));
            _account.Logger.LogInfo(LanguageManager.Translate("107"), LanguageManager.Translate("374", spell.Name, level));
            return true;
        }

        public void ChangeStatus(PlayerStatusEnum status)
        {
            if (Status == status)
                return;

            _account.Network.SendMessage(new PlayerStatusUpdateRequestMessage(new PlayerStatus((uint)status)));
        }

        public string GetSkinUrl(string mode, int orientation, int width, int height, int zoom)
        {
            EntityLook look = Look;
            string text = "http://staticns.ankama.com/dofus/renderer/look/7";
            text += "b3";
            int num = 0;
            char[] array = look.BonesId.ToString().ToCharArray();
            char[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                char c = array2[i];
                int num2 = num;
                num = num2 + 1;
                text += c.ToString();
                bool flag = num >= array.Length;
                if (flag)
                {
                    text += "7";
                }
                else
                {
                    text += "3";
                }
            }
            int num3 = 0;
            int num4 = 0;
            foreach (ushort current in look.Skins)
            {
                int num2 = num3;
                num3 = num2 + 1;
                text += "c3";
                char[] array3 = current.ToString().ToCharArray();
                char[] array4 = array3;
                for (int j = 0; j < array4.Length; j++)
                {
                    char c2 = array4[j];
                    num2 = num4;
                    num4 = num2 + 1;
                    text += c2.ToString();
                    bool flag2 = num4 >= array3.Length && num3 < look.Skins.Count;
                    if (flag2)
                    {
                        text += "2";
                        num4 = 0;
                    }
                    else
                    {
                        bool flag3 = num4 < array3.Length && num3 <= look.Skins.Count;
                        if (flag3)
                        {
                            text += "3";
                        }
                    }
                }
                bool flag4 = num3 >= look.Skins.Count;
                if (flag4)
                {
                    text += "7";
                }
            }
            int num5 = 0;
            foreach (int current2 in look.IndexedColors)
            {
                int num2 = num5;
                num5 = num2 + 1;
                text = string.Concat(new object[]
                {
                    text,
                    "c3",
                    num5,
                    "3d3"
                });
                num4 = 0;
                char[] array5 = current2.ToString().ToCharArray();
                char[] array6 = array5;
                for (int k = 0; k < array6.Length; k++)
                {
                    char c3 = array6[k];
                    num2 = num4;
                    num4 = num2 + 1;
                    text += c3.ToString();
                    bool flag5 = num4 >= array5.Length && num5 < look.IndexedColors.Count;
                    if (flag5)
                    {
                        text += "2";
                        num4 = 0;
                    }
                    else
                    {
                        bool flag6 = num4 < array5.Length && num5 <= look.IndexedColors.Count;
                        if (flag6)
                        {
                            text += "3";
                        }
                    }
                }
                bool flag7 = num5 >= look.IndexedColors.Count;
                if (flag7)
                {
                    text += "7";
                }
            }
            int num6 = 0;
            foreach (short current3 in look.Scales)
            {
                int num2 = num6;
                num6 = num2 + 1;
                text += "c3";
                num4 = 0;
                char[] array7 = current3.ToString().ToCharArray();
                char[] array8 = array7;
                for (int l = 0; l < array8.Length; l++)
                {
                    char c4 = array8[l];
                    num2 = num4;
                    num4 = num2 + 1;
                    text += c4.ToString();
                    bool flag8 = num4 >= array7.Length && num6 < look.Scales.Count;
                    if (flag8)
                    {
                        text += "2";
                        num4 = 0;
                    }
                    else
                    {
                        bool flag9 = num4 < array7.Length && num6 <= look.Scales.Count;
                        if (flag9)
                        {
                            text += "3";
                        }
                    }
                }
                bool flag10 = num6 >= look.Scales.Count;
                if (flag10)
                {
                    text += "7";
                }
            }
            text = string.Concat(new object[]
            {
                text,
                "d/",
                mode,
                "/",
                orientation,
                "/",
                width,
                "_",
                height,
                "-",
                zoom,
                ".png"
            });
            return text;
        }

        public void Clear()
        {
            IsSelected = false;
            Mount.Clear();
        }

        #region Updates

        public void Update(CharacterSelectedSuccessMessage message)
        {
            Id = message.Infos.Id;
            Name = message.Infos.Name;
            Level = (byte)message.Infos.Level;
            Breed = (BreedEnum)message.Infos.Breed;
            Sex = message.Infos.Sex;
            Look = message.Infos.EntityLook;
            SkinUrl = GetSkinUrl("full", 1, 128, 256, 0);
            _breedData = DataManager.Get<Breeds>(message.Infos.Breed);
            Status = PlayerStatusEnum.PLAYER_STATUS_AVAILABLE;
            LifeStatus = PlayerLifeStatusEnum.STATUS_ALIVE_AND_KICKING;

            _account.Configuration.Load();
            _account.Extensions.Fights.Configuration.Load();
            _account.Extensions.Bid.Configuration.Load();
            _account.Extensions.Flood.Configuration.Load();

            IsSelected = true;
            CharacterSelected?.Invoke();
        }

        public void Update(CharacterStatsListMessage message)
        {
            Stats.Update(message);
            Inventory.Update(message);

            StatsUpdated?.Invoke();
        }

        public void Update(CharacterLevelUpMessage message)
        {
            Level = (byte)message.NewLevel;

            StatsUpdated?.Invoke();
        }

        public void Update(GameRolePlayPlayerLifeStatusMessage message)
        {
            LifeStatus = (PlayerLifeStatusEnum)message.State;
        }

        public void Update(PlayerStatusUpdateMessage message)
        {
            Status = (PlayerStatusEnum)message.Status.StatusId;
        }

        public void Update(SpellListMessage message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Spells.Clear();

                var spells = DataManager.GetList<Spells>(message.Spells.Select(f => f.SpellId));
                for (int i = 0; i < message.Spells.Count; i++)
                {
                    Spells.Add(new SpellEntry(message.Spells[i], spells.FirstOrDefault(f => f.Id == message.Spells[i].SpellId)));
                }
            });

            SpellsUpdated?.Invoke();
        }

        public void Update(SpellUpgradeSuccessMessage message)
        {
            var spell = GetSpell(message.SpellId);

            Application.Current.Dispatcher.Invoke(() =>
            {
                if (spell != null)
                {
                    spell.Update(message);
                }
                else
                {
                    Spells.Add(new SpellEntry(message.SpellId, message.SpellLevel));
                }
            });

            SpellsUpdated?.Invoke();
        }

        public void Update(EmotePlayMessage message)
        {
            if (message.ActorId != Id)
                return;

            if (message.EmoteId == 1 && _account.State != AccountStates.REGENERATING)
            {
                _account.State = AccountStates.REGENERATING;
            }
            else if (message.EmoteId == 0 && _account.State == AccountStates.REGENERATING)
            {
                _account.State = AccountStates.NONE;
            }
        }

        public void Update(LifePointsRegenBeginMessage message)
        {
            _regenTimer.Change(Timeout.Infinite, Timeout.Infinite);
            _regenTimer.Change(message.RegenRate * 100, message.RegenRate * 100);
        }

        public void Update(LifePointsRegenEndMessage message)
        {
            _regenTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        #endregion

        private void RegenTimerCallback(object state)
        {
            try
            {
                if (Stats?.LifePoints >= Stats?.MaxLifePoints)
                {
                    _regenTimer.Change(Timeout.Infinite, Timeout.Infinite);
                    return;
                }

                _account.Game.Character.Stats.LifePoints++;
            }
            catch { }
        }

        private uint GetNeededPointsToBoostStat(BoostableStats stat)
        {
            List<List<int>> data = null;
            int baseStats = 0;

            switch (stat)
            {
                case BoostableStats.AGILITY:
                    data = _breedData.StatsPointsForAgility;
                    baseStats = Stats.Agility.Base;
                    break;
                case BoostableStats.CHANCE:
                    data = _breedData.StatsPointsForChance;
                    baseStats = Stats.Chance.Base;
                    break;
                case BoostableStats.INTELLIGENCE:
                    data = _breedData.StatsPointsForIntelligence;
                    baseStats = Stats.Intelligence.Base;
                    break;
                case BoostableStats.STRENTH:
                    data = _breedData.StatsPointsForStrength;
                    baseStats = Stats.Strength.Base;
                    break;
                case BoostableStats.VITALITY:
                    data = _breedData.StatsPointsForVitality;
                    baseStats = Stats.Vitality.Base;
                    break;
                case BoostableStats.WISDOM:
                    data = _breedData.StatsPointsForWisdom;
                    baseStats = Stats.Wisdom.Base;
                    break;
            }

            return (uint)data.FindLast(d => baseStats >= d[0])[1];
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Inventory.Dispose();
                    Jobs.Dispose();
                    Mount.Dispose();
                    _regenTimer.Dispose();
                }

                Stats = null;
                Name = null;
                _breedData = null;
                Inventory = null;
                Mount = null;
                Jobs = null;
                Spells = null;
                IsSelected = false;
                _account = null;
                _regenTimer = null;

                _disposedValue = true;
            }
        }

        ~CharacterGame() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}
