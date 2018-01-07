using MercyBot.Core.Accounts.Extensions.Fights.Configuration;
using MercyBot.Core.Accounts.Extensions.Fights.Configuration.Enums;
using MercyBot.Core.Accounts.Extensions.Fights.Utility;
using MercyBot.Core.Accounts.InGame.Fights.Fighters;
using MercyBot.Core.Pathfinding;
using MercyBot.Protocol.Data;
using MercyBot.Protocol.Enums;
using MercyBot.Protocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;
using MercyBot.Core.Accounts.Extensions.CharacterCreator;

namespace MercyBot.Core.Accounts.Extensions.Fights
{
    public class FightsExtension : IClearable, IDisposable
    {

        // Fields
        private Account _account;
        private SpellsManager _spellsManager;
        private FightsUtility _utility;
        private int _spellIndex;
        private bool _endTurn;
        private byte _turnId;
        private bool _spellCasted;
        private bool _awaitingSequenceEnd;


        // Properties
        public FightsConfiguration Configuration { get; private set; }

        private List<Spell> Spells => _account.Extensions.CharacterCreation.IsDoingTutorial
            ? TutorialHelper.BaseSpells[_account.Game.Character.Breed]
            : Configuration.Spells.ToList();


        // Constructor
        public FightsExtension(Account account)
        {
            _account = account;
            _spellsManager = new SpellsManager(_account);
            _utility = new FightsUtility(_account);
            Configuration = new FightsConfiguration(account);

            SetEvents();
        }


        private void SetEvents()
        {
            _account.Game.Fight.TurnStarted += Fight_TurnStarted;
            _account.Game.Fight.TurnEnded += Fight_TurnEnded;
            _account.Game.Fight.FightJoined += Fight_FightJoined;
            _account.Game.Fight.SpectatorJoined += Fight_SpectatorJoined;
        }

        private void Fight_FightJoined()
        {
            _turnId = 0;
            foreach (var s in Spells)
            {
                s.LastTurn = 0;
                s.RemainingRelaunchs = s.Relaunchs;
            }
        }

        private async void Fight_SpectatorJoined()
        {
            if (Configuration.BlockSpectatorScenario == BlockSpectatorScenarios.WHEN_SOMEONE_JOINS)
            {
                await _account.Game.Fight.ToggleOption(FightOptionsEnum.FIGHT_OPTION_SET_SECRET);
            }
        }

        #region Fight Turn

        private async void Fight_TurnStarted()
        {
            _turnId++;
            _account.Logger.LogInfo(LanguageManager.Translate("472"), LanguageManager.Translate("47", _turnId));
            _spellIndex = 0;
            _endTurn = false;
            _spellCasted = false;
            _awaitingSequenceEnd = false;

            // For example mules that just need to move (or not) and pass turn
            // Also end turn if there are no visibile monsters
            if (Spells.Count == 0 || !_account.Game.Fight.Ennemies.Any())
            {
                await EndTurn();
                return;
            }

            Console.WriteLine("1- Calling ProcessSpells");
            await ProcessSpells();
        }

        private void Fight_TurnEnded()
        {
            _account.Logger.LogInfo(LanguageManager.Translate("472"), LanguageManager.Translate("48"));
        }

        private async Task ProcessSpells()
        {
            if (_account?.IsFighting() == false || Configuration == null)
                return;

            Console.WriteLine(LanguageManager.Translate("49"));
            // If we finished all the spells
            if (_spellIndex >= Spells.Count)
            {
                Console.WriteLine(LanguageManager.Translate("50"));
                await EndTurn();
                return;
            }

            // Otherwise handle the current spell
            var currentSpell = Spells[_spellIndex];

            // If we have no more relaunchs, go to the next spell
            if (currentSpell.RemainingRelaunchs == 0)
            {
                Console.WriteLine(LanguageManager.Translate("51"));
                await ProcessNextSpell(currentSpell, true);
                return;
            }

            // Otherwise handle the spell
            // Check if we can cast this spell this turn
            if (!(_turnId == 1 || currentSpell.LastTurn == 0 || currentSpell.Turns == 1 || _turnId == currentSpell.LastTurn + currentSpell.Turns))
            {
                Console.WriteLine(LanguageManager.Translate("53"));
                await ProcessNextSpell(currentSpell);
                return;
            }

            var result = await _spellsManager.ManageSpell(currentSpell);
            //_account.Logger.LogDebug("", result.ToString());

            switch (result)
            {
                // If we failed to cast the spell, go to the next one
                case SpellCastingResults.NOT_CASTED:
                    // Without setting the LastTurn property
                    await ProcessNextSpell(currentSpell);
                    break;
                case SpellCastingResults.CASTED:
                    _spellCasted = true;
                    currentSpell.RemainingRelaunchs--;
                    _awaitingSequenceEnd = true;
                    break;
                case SpellCastingResults.MOVED:
                    _awaitingSequenceEnd = true;
                    break;
            }
        }

        private async Task ProcessNextSpell(Spell currentSpell, bool updateLastTurn = false)
        {
            if (_account?.IsFighting() == false)
                return;

            currentSpell.RemainingRelaunchs = currentSpell.Relaunchs;
            _spellIndex++;

            if (updateLastTurn)
            {
                currentSpell.LastTurn = _turnId;
            }

            Console.WriteLine("2- Calling ProcessSpells");
            await ProcessSpells();
        }

        public async Task Update(GameActionFightNoSpellCastMessage message)
        {
            _account.Logger.LogError(LanguageManager.Translate("472"), LanguageManager.Translate("54"));

            try
            {
                if (_spellIndex >= Spells.Count)
                {
                    await EndTurn();
                }
                else
                {
                    await ProcessNextSpell(Spells[_spellIndex]);
                }
            }
            catch { }
        }

        public void Update(GameMapNoMovementMessage message)
        {
            //await FinishTurn(400);
        }

        public async Task Update(SequenceEndMessage message)
        {
            if (!_account.Game.Fight.IsOurTurn || message.AuthorId != _account.Game.Character.Id)
                return;

            // If all the ennemies are dead, avoid doing something
            if (_account.Game.Fight.AliveEnnemiesCount == 0)
                return;

            // If its the end of the turn
            if (_endTurn && message.SequenceType == 5)
            {
                await FinishTurn(400);
                return;
            }

            if (_awaitingSequenceEnd)
                _awaitingSequenceEnd = false;
            else
                return;

            // Otherwise handle the spells
            await Task.Delay(400);
            Console.WriteLine("3- Calling ProcessSpells");
            await ProcessSpells();
        }

        #region End Move

        private async Task EndTurn()
        {
            if (!_account.Game.Fight.IsOurTurn)
                return;

            Console.WriteLine("EndTurn");
            if (Configuration.Tactic == FightTactics.PASSIVE)
            {
                await FinishTurn(400);
                return;
            }

            // If we're h2h then just avoid this
            if (_account.Game.Fight.IsHandToHandWithAnEnnemy() && Configuration.Tactic == FightTactics.AGRESSIVE)
            {
                await FinishTurn(400);
                return;
            }

            if (_account.Game.Fight.PlayedFighter.MovementPoints > 0 && _account.Game.Fight.Ennemies.Any())
            {
                // If no spell was casted, approach even if the tactic is fugitive
                // Also if distance to the nearest ennemy is >= MaxCells
                bool nearest = Configuration.Tactic == FightTactics.AGRESSIVE ||
                               (Configuration.ApproachWhenNoSpellWasCasted || _account.Extensions.CharacterCreation.IsDoingTutorial) && !_spellCasted ||
                               MapPoint.FromCellId(_account.Game.Fight.GetNearestEnnemy().CellId).DistanceToCell(MapPoint.FromCellId(_account.Game.Fight.PlayedFighter.CellId)) >= Configuration.MaxCells;
                var node = _utility.GetNearestOrFarthestEndMoveNode(nearest, (Configuration.Tactic == FightTactics.FUGITIVE || Configuration.BaseApproachOnAllMonsters));

                if (node != null)
                {
                    _endTurn = true;
                    _account.Logger.LogDebug(LanguageManager.Translate("472"), LanguageManager.Translate("56", node.Value.Key));
                    await _account.Game.Managers.Movements.MoveToCellInFight(node);
                    return;
                }
            }

            await FinishTurn(400);
        }

        private async Task FinishTurn(int delay)
        {
            await Task.Delay(delay);
            _account.Logger.LogDebug(LanguageManager.Translate("472"), LanguageManager.Translate("57"));
            await _account.Network.SendMessageAsync(new GameFightTurnFinishMessage());
        }

        #endregion

        #endregion

        #region Fight Start

        public async Task Update(GameFightPlacementPossiblePositionsMessage message)
        {
            // TODO: Find a better way
            // Wait a little to make sure all the ennemis are in the fight
            await Task.Delay(1000);

            // Check if we should lock the fight
            if (Configuration.LockFight)
            {
                await _account.Game.Fight.ToggleOption(FightOptionsEnum.FIGHT_OPTION_SET_CLOSED);
            }

            await Task.Delay(300);

            // Check if we should block spectator mode
            if (Configuration.BlockSpectatorScenario == BlockSpectatorScenarios.ALWAYS)
            {
                await _account.Game.Fight.ToggleOption(FightOptionsEnum.FIGHT_OPTION_SET_SECRET);
            }

            await Task.Delay(300);

            var possiblePositions = _account.Game.Fight.PlayedFighter.Team == TeamEnum.TEAM_CHALLENGER ?
                                    message.PositionsForChallengers.Except(_account.Game.Fight.Allies.Select(a => (uint)a.CellId)).ToList() :
                                    message.PositionsForDefenders.Except(_account.Game.Fight.Allies.Select(a => (uint)a.CellId)).ToList();

            Console.WriteLine("{0} - {1} possible positions.", _account.AccountConfig.Username, possiblePositions.Count);

            // Approach a monster
            if (!(await TryApproachingMonster(possiblePositions)))
            {
                // Approach to cast a spell
                if (!(await TryApproachingForSpell(possiblePositions)))
                {
                    // Placements
                    if (Configuration.FightStartPlacement != FightStartPlacements.STAY_STILL)
                    {
                        short cellId = _utility.GetNearestOrFarthestCell(Configuration.FightStartPlacement == FightStartPlacements.CLOSE_TO_ENNEMIS,
                            possiblePositions.Select(f => (short)f));

                        // If we're not already close
                        if (cellId != _account.Game.Fight.PlayedFighter.CellId)
                        {
                            _account.Logger.LogDebug(LanguageManager.Translate("472"), LanguageManager.Translate("58", cellId));
                            await _account.Network.SendMessageAsync(new GameFightPlacementPositionRequestMessage((uint)cellId));
                        }
                        else
                        {
                            Console.WriteLine("{0} SAME CELL", _account.AccountConfig.Username);
                        }
                    }
                }
            }

            // If this account is a group chief, wait for the group members to join (or for the fight to start :/)
            if (_account.HasGroup && _account.IsGroupChief)
            {
                await _account.Group.WaitForMembersToJoinFight();

                // Group special case: If one of the members didin't join, and the fight started, there is no need to send Ready message
                if (_account.Game.Fight.IsFightStarted)
                    return;
            }

            await Task.Delay(300);
            await _account.Network.SendMessageAsync(new GameFightReadyMessage(true));
        }

        public async Task Update(GameFightShowFighterMessage message)
        {
            // Avoid kicking monsters or ourselves..
            if (_account.Game.Fight.Allies.FirstOrDefault(a => a.ContextualId == message.Informations.ContextualId) == null)
                return;

            // If this account is a group chief and a non-member joins the fight
            if (_account.HasGroup && _account.IsGroupChief)
            {
                if (!_account.Group.IsGroupMember(message.Informations.ContextualId))
                {
                    await Task.Delay(800);
                    await _account.Network.SendMessageAsync(new GameContextKickMessage(message.Informations.ContextualId));
                    _account.Logger.LogWarning(LanguageManager.Translate("472"), LanguageManager.Translate("393"));

                    // If this person took a member's place, send a group signal so that the member joins again
                    _account.Group.SignalMembersToJoinFight();
                }
            }
        }

        private async Task<bool> TryApproachingForSpell(List<uint> possiblePlacements)
        {
            if (Configuration.SpellToApproach == -1)
                return false;

            var spell = DataManager.Get<Spells>(Configuration.SpellToApproach);
            var spellLevel = DataManager.Get<SpellLevels>(spell.SpellLevels[_account.Game.Character.GetSpell(spell.Id).Level - 1]);

            // Check if we can cast the spell from our current position
            if (_utility.SpellIsHittingAnyEnnemy(_account.Game.Fight.PlayedFighter.CellId, spellLevel))
                return true;

            // Otherwise check for the other cells
            for (int i = 0; i < possiblePlacements.Count; i++)
            {
                // Avoid re-checking our current position
                if (possiblePlacements[i] == _account.Game.Fight.PlayedFighter.CellId)
                    continue;

                if (_utility.SpellIsHittingAnyEnnemy((short)possiblePlacements[i], spellLevel))
                {
                    _account.Logger.LogDebug(LanguageManager.Translate("472"), LanguageManager.Translate("59", possiblePlacements[i]));
                    await _account.Network.SendMessageAsync(new GameFightPlacementPositionRequestMessage(possiblePlacements[i]));
                    return true;
                }
            }

            return false;
        }

        private async Task<bool> TryApproachingMonster(List<uint> possiblePlacements)
        {
            if (Configuration.MonsterToApproach == -1)
                return false;

            FightMonsterEntry monster = _account.Game.Fight.Monsters.FirstOrDefault(f => f.CreatureGenericId == Configuration.MonsterToApproach);
            if (monster == null)
            {
                _account.Logger.LogDebug(LanguageManager.Translate("472"), LanguageManager.Translate("60"));
                return false;
            }
            // The monster to approach is in the fight !
            else
            {
                short cellId = -1;
                int distance = -1;

                foreach (short cell in possiblePlacements)
                {
                    if (cellId == -1 || (MapPoint.FromCellId(monster.CellId).DistanceToCell(MapPoint.FromCellId(cell)) < distance))
                    {
                        cellId = cell;
                        distance = MapPoint.FromCellId(monster.CellId).DistanceToCell(MapPoint.FromCellId(cell));
                    }
                }

                // If we're not already close
                if (cellId != _account.Game.Fight.PlayedFighter.CellId)
                {
                    _account.Logger.LogDebug(LanguageManager.Translate("472"), LanguageManager.Translate("61", cellId));
                    await _account.Network.SendMessageAsync(new GameFightPlacementPositionRequestMessage((uint)cellId));
                }

                return true;
            }
        }

        #endregion

        public void Clear()
        {
            _turnId = 0;
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Configuration.Dispose();
                    _spellsManager.Dispose();
                    _utility.Dispose();
                }

                Configuration = null;
                _spellsManager = null;
                _utility = null;
                _account = null;

                _disposedValue = true;
            }
        }

        ~FightsExtension() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}
