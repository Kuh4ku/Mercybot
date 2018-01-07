using System;
using System.Collections.Generic;
using MercyBot.Protocol.Messages;
using MercyBot.Protocol.Enums;
using MercyBot.Core.Accounts.InGame.Fights.Fighters;
using MercyBot.Protocol.Types;
using System.Linq;
using MercyBot.Protocol.Data;
using MercyBot.Core.Pathfinding;
using MercyBot.Core.Pathfinding.Shapes;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using MercyBot.Core.Enums;

namespace MercyBot.Core.Accounts.InGame.Fights
{
    public class FightGame : IClearable, IDisposable
    {

        // Fields
        private Account _account;
        private ConcurrentDictionary<int, FighterEntry> _fighters;
        private ConcurrentDictionary<int, FighterEntry> _ennemies;
        private ConcurrentDictionary<int, FighterEntry> _allies;
        private Dictionary<int, int> _effectsDurations;
        private Dictionary<int, int> _spellsIntervals;
        private Dictionary<int, int> _totalSpellLaunchs;
        private Dictionary<int, Dictionary<int, int>> _totalSpellLaunchsInCells;


        // Properties
        public FightTypeEnum Type { get; private set; }
        public bool IsFightStarted { get; private set; }
        public List<FightOptionsEnum> Options { get; private set; }
        public FightPlayerEntry PlayedFighter { get; private set; }
        public bool IsOurTurn { get; private set; }
        public int RoundNumber { get; private set; }
        public List<short> PositionsForChallengers { get; private set; }
        public List<short> PositionsForDefenders { get; private set; }
        public uint FightId { get; private set; }

        public IEnumerable<FighterEntry> Allies => _allies.Values.Where(a => a.Alive);
        public IEnumerable<FighterEntry> Ennemies => _ennemies.Values.Where(e => e.Alive && e.Stats.InvisibilityState != 1);
        public IEnumerable<FightMonsterEntry> Monsters => Ennemies.OfType<FightMonsterEntry>();
        public IEnumerable<FighterEntry> Fighters => _fighters.Values.Where(f => f.Alive);
        public int InvocationsCount => Fighters.Count(f => f.Stats.Summoner == PlayedFighter.ContextualId);
        public int AliveEnnemiesCount => Ennemies.Count(f => f.Alive);
        public List<short> OccupiedCells => Fighters.Select(f => f.CellId).ToList();


        // Events
        public event Action FightJoined;
        public event Action FightIdReceived;
        public event Action FightStarted;
        public event Action FightEnded;
        public event Action SpectatorJoined;
        public event Action TurnStarted;
        public event Action TurnEnded;
        public event Action FightersUpdated;
        public event Action FighterStatsUpdated;
        public event Action PossiblePositionsReceived;
        public event Action<List<short>> PlayedFighterMoving;


        // Constructor
        public FightGame(Account account)
        {
            _account = account;

            _fighters = new ConcurrentDictionary<int, FighterEntry>();
            _ennemies = new ConcurrentDictionary<int, FighterEntry>();
            _allies = new ConcurrentDictionary<int, FighterEntry>();
            _effectsDurations = new Dictionary<int, int>();
            _totalSpellLaunchs = new Dictionary<int, int>();
            _spellsIntervals = new Dictionary<int, int>();
            _totalSpellLaunchsInCells = new Dictionary<int, Dictionary<int, int>>();
            Options = new List<FightOptionsEnum>();
        }


        #region Public Methods

        public async Task ToggleOption(FightOptionsEnum option)
        {
            if (_account.State != Enums.AccountStates.FIGHTING)
                return;

            if (!Options.Contains(option))
            {
                await _account.Network.SendMessageAsync(new GameFightOptionToggleMessage((uint)option));
            }
        }

        public async Task LaunchSpell(int spellId, short cellId)
        {
            if (_account.State != Enums.AccountStates.FIGHTING)
                return;

            // TODO: Check why DT always sends CastRequest
            //if (GetFighterInCell(cellId) != null)
            //{
            //    await _account.Network.SendMessageAsync(new GameActionFightCastOnTargetRequestMessage((uint)spellId, cellId));
            //}
            //else
            //{
            await _account.Network.SendMessageAsync(new GameActionFightCastRequestMessage((uint)spellId, cellId));
            //}
        }

        public bool HasState(int stateId)
            => _effectsDurations.ContainsKey(stateId);

        public FighterEntry GetFighter(int id)
        {
            if (PlayedFighter != null && PlayedFighter.ContextualId == id)
            {
                return PlayedFighter;
            }

            return _fighters.TryGetValue(id, out FighterEntry fighter) ? fighter : null;
        }

        public FighterEntry GetFighterInCell(short cell)
        {
            if (PlayedFighter?.CellId == cell) return PlayedFighter;
            return Fighters.FirstOrDefault(f => f.Alive && f.CellId == cell);
        }

        public bool IsCellFree(short cellId)
            => GetFighterInCell(cellId) == null;

        public FighterEntry GetNearestEnnemy(short cellId = -1, Func<FighterEntry, bool> filter = null)
        {
            MapPoint charMp = MapPoint.FromCellId(cellId == -1 ? PlayedFighter.CellId : cellId), ennemyMp;
            int distance = -1, tempDistance;
            FighterEntry ennemy = null;

            foreach (var ennemyEntry in filter == null ? Ennemies : Ennemies.Where(f => filter(f)))
            {
                if (!ennemyEntry.Alive)
                    continue;

                ennemyMp = MapPoint.FromCellId(ennemyEntry.CellId);
                tempDistance = charMp.DistanceToCell(ennemyMp);

                if (distance == -1 || tempDistance < distance)
                {
                    distance = tempDistance;
                    ennemy = ennemyEntry;
                }
            }

            return ennemy;
        }

        public FighterEntry GetWeakestEnnemy()
        {
            int lp = -1;
            FighterEntry ennemy = null;

            foreach (var ennemyEntry in Ennemies)
            {
                if (!ennemyEntry.Alive)
                    continue;

                if (lp == -1 || ennemyEntry.LifePercent < lp)
                {
                    lp = ennemyEntry.LifePercent;
                    ennemy = ennemyEntry;
                }
            }

            return ennemy;
        }

        public FighterEntry GetNearestAlly(Func<FighterEntry, bool> filter = null)
        {
            MapPoint charMp = MapPoint.FromCellId(PlayedFighter.CellId), allyMp;
            int distance = -1, tempDistance;
            FighterEntry ally = null;

            foreach (var allyEntry in filter == null ? Allies : Allies.Where(f => filter(f)))
            {
                if (!allyEntry.Alive)
                    continue;

                allyMp = MapPoint.FromCellId(allyEntry.CellId);
                tempDistance = charMp.DistanceToCell(allyMp);

                if (distance == -1 || tempDistance < distance)
                {
                    distance = tempDistance;
                    ally = allyEntry;
                }
            }

            return ally;
        }

        public FighterEntry GetWeakestAlly()
        {
            int lp = -1;
            FighterEntry ally = null;

            foreach (var allyEntry in Allies)
            {
                if (!allyEntry.Alive)
                    continue;

                if (lp == -1 || allyEntry.LifePercent < lp)
                {
                    lp = allyEntry.LifePercent;
                    ally = allyEntry;
                }
            }

            return ally;
        }

        public IEnumerable<FighterEntry> GetHandToHandEnnemies(short cellId = -1)
        {
            MapPoint charMp = MapPoint.FromCellId(cellId == -1 ? PlayedFighter.CellId : cellId);
            return Ennemies.Where(e => e.Alive && charMp.DistanceToCell(MapPoint.FromCellId(e.CellId)) == 1);
        }

        public IEnumerable<FighterEntry> GetHandToHandAllies(short cellId = -1)
        {
            MapPoint charMp = MapPoint.FromCellId(cellId == -1 ? PlayedFighter.CellId : cellId);
            return Allies.Where(a => a.Alive && charMp.DistanceToCell(MapPoint.FromCellId(a.CellId)) == 1);
        }

        public bool IsHandToHandWithAnEnnemy(short cellId = -1)
            => GetHandToHandEnnemies(cellId).Count() > 0;

        public bool IsHandToHandWithAnAlly(short cellId = -1)
            => GetHandToHandAllies(cellId).Count() > 0;

        public List<MapPoint> GetSpellZone(int spellId, short fromCellId, short targetCellId, SpellLevels spellLevel = null)
        {
            if (spellLevel == null)
            {
                var spellEntry = _account.Game.Character.GetSpell(spellId);

                if (spellEntry == null)
                    return null;

                var spell = DataManager.Get<Spells>(spellId);

                if (spell == null)
                    return null;

                spellLevel = DataManager.Get<SpellLevels>(spell.SpellLevels[spellEntry.Level - 1]);
            }

            return SpellShapes.GetSpellEffectZone(_account.Game.Map.Data, spellLevel, fromCellId, targetCellId);
        }

        public SpellInabilityReasons CanLaunchSpell(int spellId)
        {
            var spellEntry = _account.Game.Character.Spells.FirstOrDefault(f => f.Id == spellId);

            if (spellEntry == null)
                return SpellInabilityReasons.UNKNOWN;

            var spell = DataManager.Get<Spells>(spellId);
            var spellLevel = DataManager.Get<SpellLevels>(spell.SpellLevels[spellEntry.Level - 1]);

            if (PlayedFighter.ActionPoints < spellLevel.ApCost)
                return SpellInabilityReasons.ACTION_POINTS;

            if (spellLevel.MaxCastPerTurn > 0 && _totalSpellLaunchs.ContainsKey(spellId) && _totalSpellLaunchs[spellId] >= spellLevel.MaxCastPerTurn)
                return SpellInabilityReasons.TOO_MANY_LAUNCHS;

            if (_spellsIntervals.ContainsKey(spellId))
                return SpellInabilityReasons.COOLDOWN;

            if (spellLevel.InitialCooldown > 0 && RoundNumber <= spellLevel.InitialCooldown)
                return SpellInabilityReasons.COOLDOWN;

            if (spellLevel.Effects.Count > 0 && spellLevel.Effects[0].Value<int>("effectId") == 181 && InvocationsCount >= _account.Game.Character.Stats.SummonableCreaturesBoost.Total)
                return SpellInabilityReasons.TOO_MANY_INVOCATIONS;

            if (spellLevel.StatesRequired.Any(f => !_effectsDurations.ContainsKey(f)))
                return SpellInabilityReasons.REQUIRED_STATE;

            if (spellLevel.StatesForbidden.Any(f => _effectsDurations.ContainsKey(f)))
                return SpellInabilityReasons.FORBIDDEN_STATE;

            return SpellInabilityReasons.NONE;
        }

        public SpellInabilityReasons CanLaunchSpell(int spellId, short characterCellId, short targetCellId)
        {
            var spellEntry = _account.Game.Character.Spells.FirstOrDefault(f => f.Id == spellId);

            if (spellEntry == null)
                return SpellInabilityReasons.UNKNOWN;

            var spell = DataManager.Get<Spells>(spellId);
            var spellLevel = DataManager.Get<SpellLevels>(spell.SpellLevels[spellEntry.Level - 1]);

            if (spellLevel.MaxCastPerTarget > 0 && _totalSpellLaunchsInCells.ContainsKey(spellId) &&
                _totalSpellLaunchsInCells[spellId].ContainsKey(targetCellId) && _totalSpellLaunchsInCells[spellId][targetCellId] >= spellLevel.MaxCastPerTarget)
                return SpellInabilityReasons.TOO_MANY_LAUNCHS_ON_CELL;

            if (spellLevel.NeedFreeCell && !IsCellFree(targetCellId))
                return SpellInabilityReasons.NEED_FREE_CELL;

            if (spellLevel.NeedTakenCell && IsCellFree(targetCellId))// && characterCellId != targetCellId))
                return SpellInabilityReasons.NEED_TAKEN_CELL;

            // TODO: Not 100% sure this works flawlessly
            if (!GetSpellRange(characterCellId, spellLevel).Contains(targetCellId))
                return SpellInabilityReasons.NOT_IN_RANGE;

            return SpellInabilityReasons.NONE;
        }

        public List<short> GetSpellRange(short characterCellId, SpellLevels spellLevel)
        {
            List<short> range = new List<short>();

            foreach (var mp in SpellShapes.GetSpellRange(characterCellId, spellLevel, _account.Game.Character.Stats.Range.Total))
            {
                if (mp == null || range.Contains(mp.CellId))
                    continue;

                if (spellLevel.NeedFreeCell && OccupiedCells.Contains(mp.CellId))
                    continue;

                if ((_account.Game.Map.Data.Cells[mp.CellId].l & 7) == 3)
                    range.Add(mp.CellId);
            }

            if (spellLevel.CastTestLos)
            {
                for (int i = range.Count - 1; i >= 0; i--)
                {
                    if (Dofus1Line.IsLineObstructed(_account.Game.Map.Data, characterCellId, range[i], OccupiedCells, spellLevel.CastInDiagonal))
                        range.RemoveAt(i);
                }
            }

            return range;
        }

        #endregion

        public void Clear()
        {
            _fighters.Clear();
            _ennemies.Clear();
            _allies.Clear();
            _effectsDurations.Clear();
            _spellsIntervals.Clear();
            _totalSpellLaunchs.Clear();
            _totalSpellLaunchsInCells.Clear();

            IsFightStarted = false;
            Options.Clear();
            PlayedFighter = null;
            IsOurTurn = false;
            RoundNumber = 0;
            FightId = 0;
            PositionsForChallengers?.Clear();
            PositionsForDefenders?.Clear();
        }

        #region Updates

        public void Update(GameFightJoinMessage message)
        {
            Type = (FightTypeEnum)message.FightType;
            IsFightStarted = message.IsFightStarted;

            _account.State = AccountStates.FIGHTING;
            FightJoined?.Invoke();
        }

        public void Update(GameFightPlacementPossiblePositionsMessage message)
        {
            PositionsForChallengers = message.PositionsForChallengers.Select(c => (short)c).ToList();
            PositionsForDefenders = message.PositionsForDefenders.Select(c => (short)c).ToList();

            PossiblePositionsReceived?.Invoke();
        }

        public void Update(GameFightStartMessage message)
        {
            IsFightStarted = true;
            PositionsForChallengers.Clear();
            PositionsForDefenders.Clear();

            FightStarted?.Invoke();
        }

        public void Update(TextInformationMessage message)
        {
            if (message.MsgType == 36)
                SpectatorJoined?.Invoke();
        }

        public void Update(GameFightShowFighterMessage message)
        {
            if (message.Informations.ContextualId == _account.Game.Character.Id)
            {
                PlayedFighter = new FightPlayerEntry(message.Informations);
            }
            else
            {
                AddFighter(message.Informations);
            }

            SortFighters();
            FightersUpdated?.Invoke();
        }

        public void Update(GameFightUpdateTeamMessage message)
        {
            if (_account.State == AccountStates.FIGHTING && message.Team.LeaderId == _account.Game.Character.Id && FightId == 0)
            {
                FightId = message.FightId;
                FightIdReceived?.Invoke();
            }
        }

        public void Update(GameFightOptionStateUpdateMessage message)
        {
            FightOptionsEnum option = (FightOptionsEnum)message.Option;
            if (!message.State && Options.Contains(option))
            {
                Options.Remove(option);
            }
            else if (message.State && !Options.Contains(option))
            {
                Options.Add(option);
            }
        }

        public void Update(GameEntitiesDispositionMessage message)
        {
            message.Dispositions.ForEach(d => GetFighter(d.Id)?.Update(d));
            FightersUpdated?.Invoke();
        }

        public void Update(GameFightSynchronizeMessage message)
        {
            message.Fighters.ForEach(f =>
            {
                var fighter = GetFighter(f.ContextualId);

                if (fighter == null)
                {
                    AddFighter(f);
                    SortFighters();
                }
                else
                {
                    fighter.Update(f);
                }
            });

            FightersUpdated?.Invoke();
        }

        public void Update(FighterStatsListMessage message)
        {
            PlayedFighter?.Update(message.Stats);

            if (PlayedFighter != null)
            {
                _account.Game.Character.Stats.MaxLifePoints = (uint)PlayedFighter?.MaxLifePoints;
                _account.Game.Character.Stats.LifePoints = (uint)PlayedFighter?.LifePoints;
            }

            FighterStatsUpdated?.Invoke();
        }

        public void Update(GameActionFightPointsVariationMessage message)
        {
            GetFighter(message.TargetId)?.Update(message);
        }

        public void Update(GameActionFightDeathMessage message)
        {
            GetFighter(message.TargetId)?.Update(message);
        }

        public void Update(GameActionFightTeleportOnSameMapMessage message)
        {
            GetFighter(message.TargetId)?.Update(message);
        }

        public void Update(GameMapMovementMessage message)
        {
            var fighter = GetFighter(message.ActorId);

            if (fighter != null)
            {
                fighter.Update(message);

                if (fighter.ContextualId == PlayedFighter?.ContextualId)
                {
                    PlayedFighterMoving?.Invoke(message.KeyMovements.Select(c => (short)c).ToList());
                }
                else
                {
                    FightersUpdated?.Invoke();
                }
            }
        }

        public void Update(GameActionFightSlideMessage message)
        {
            GetFighter(message.TargetId)?.Update(message);
            FightersUpdated?.Invoke();
        }

        public void Update(GameActionFightSummonMessage message)
        {
            AddFighter(message.Summon);
            SortFighters();

            FightersUpdated?.Invoke();
        }

        public void Update(GameActionFightLifePointsLostMessage message)
        {
            GetFighter(message.TargetId)?.Update(message);

            // Trigger update event if its our character
            if (message.TargetId == PlayedFighter?.ContextualId)
            {
                _account.Game.Character.Stats.MaxLifePoints = (uint)PlayedFighter?.MaxLifePoints;
                _account.Game.Character.Stats.LifePoints = (uint)PlayedFighter?.LifePoints;
                FighterStatsUpdated?.Invoke();
            }
        }

        public void Update(GameActionFightLifePointsGainMessage message)
        {
            GetFighter(message.TargetId)?.Update(message);

            // Trigger update event if its our character
            if (message.TargetId == PlayedFighter.ContextualId)
            {
                _account.Game.Character.Stats.MaxLifePoints = (uint)PlayedFighter?.MaxLifePoints;
                _account.Game.Character.Stats.LifePoints = (uint)PlayedFighter?.LifePoints;
                FighterStatsUpdated?.Invoke();
            }
        }

        public void Update(GameFightLeaveMessage message)
        {
            if (PlayedFighter?.ContextualId == message.CharId)
            {
                IsFightStarted = false;
            }
            else
            {
                var fighter = GetFighter(message.CharId);
                _fighters.TryRemove(fighter.ContextualId, out FighterEntry f);
                if (Allies.Contains(fighter)) _allies.TryRemove(fighter.ContextualId, out FighterEntry a);
                else if (Ennemies.Contains(fighter)) _ennemies.TryRemove(fighter.ContextualId, out FighterEntry e);
            }
        }

        public void Update(GameFightTurnStartMessage message)
        {
            if (PlayedFighter?.ContextualId == message.Id)
            {
                IsOurTurn = true;
                TurnStarted?.Invoke();
            }
        }

        public void Update(GameFightTurnEndMessage message)
        {
            var fighter = GetFighter(message.Id);

            if (fighter == PlayedFighter)
            {
                IsOurTurn = false;
                _totalSpellLaunchs.Clear();
                _totalSpellLaunchsInCells.Clear();

                // Effects
                for (int i = _effectsDurations.Count - 1; i >= 0; i--)
                {
                    int key = _effectsDurations.ElementAt(i).Key;
                    _effectsDurations[key]--;
                    if (_effectsDurations[key] == 0)
                        _effectsDurations.Remove(key);
                }

                // Spells
                for (int i = _spellsIntervals.Count - 1; i >= 0; i--)
                {
                    int key = _spellsIntervals.ElementAt(i).Key;
                    _spellsIntervals[key]--;
                    if (_spellsIntervals[key] == 0)
                        _spellsIntervals.Remove(key);
                }

                TurnEnded?.Invoke();
            }

            fighter.Update(message);
        }

        public void Update(GameActionFightDispellableEffectMessage message)
        {
            if (message.Effect is FightTemporaryBoostStateEffect ftbse)
            {
                if (ftbse.TargetId == PlayedFighter?.ContextualId)
                {
                    if (_effectsDurations.ContainsKey(ftbse.StateId))
                        _effectsDurations.Remove(ftbse.StateId);

                    //_account.Logger.LogWarning("", $"Added state{ftbse.StateId} for {ftbse.TurnDuration} turns.");
                    _effectsDurations.Add(ftbse.StateId, ftbse.TurnDuration);
                }
            }
            else if (message.Effect is FightTemporaryBoostEffect ftbe)
            {
                if (ftbe.TargetId == PlayedFighter?.ContextualId)
                {
                    PlayedFighter.Update(message.ActionId, ftbe);
                }
            }
        }

        public void Update(GameFightEndMessage message)
        {
            Clear();
            _account.State = Enums.AccountStates.NONE;

            FightEnded?.Invoke();
        }

        public void Update(GameActionFightSpellCastMessage message)
        {
            if (PlayedFighter?.ContextualId == message.SourceId)
            {
                var spell = DataManager.Get<Spells>((int)message.SpellId);
                var spellLevel = DataManager.Get<SpellLevels>(spell.SpellLevels[(int)message.SpellLevel - 1]);

                if (spellLevel.MinCastInterval > 0 && !_spellsIntervals.ContainsKey(spell.Id))
                {
                    _spellsIntervals.Add(spell.Id, spellLevel.MinCastInterval);
                }

                if (!_totalSpellLaunchs.ContainsKey(spell.Id))
                    _totalSpellLaunchs.Add(spell.Id, 0);
                _totalSpellLaunchs[spell.Id]++;

                if (_totalSpellLaunchsInCells.ContainsKey(spell.Id))
                {
                    if (!_totalSpellLaunchsInCells[spell.Id].ContainsKey(message.DestinationCellId))
                        _totalSpellLaunchsInCells[spell.Id].Add(message.DestinationCellId, 0);
                    _totalSpellLaunchsInCells[spell.Id][message.DestinationCellId]++;
                }
                else
                {
                    _totalSpellLaunchsInCells.Add(spell.Id, new Dictionary<int, int>()
                    {
                        { message.DestinationCellId, 1 }
                    });
                }
            }
        }

        public void Update(GameFightNewRoundMessage message)
        {
            RoundNumber = (int)message.RoundNumber;
        }

        #endregion

        private void SortFighters()
        {
            if (PlayedFighter == null)
                return;

            foreach (var fighter in Fighters)
            {
                if (_allies.ContainsKey(fighter.ContextualId) || _ennemies.ContainsKey(fighter.ContextualId))
                    continue;

                if (fighter.Team == PlayedFighter.Team)
                {
                    _allies.TryAdd(fighter.ContextualId, fighter);
                }
                else
                {
                    _ennemies.TryAdd(fighter.ContextualId, fighter);
                }
            }
        }

        private void AddFighter(GameFightFighterInformations informations)
        {
            if (informations is GameFightCharacterInformations || informations is GameFightMutantInformations)
            {
                _fighters.TryAdd(informations.ContextualId, new FightPlayerEntry(informations));
            }
            else if (informations is GameFightMonsterInformations mInfos)
            {
                _fighters.TryAdd(mInfos.ContextualId, new FightMonsterEntry(mInfos, informations));
                //Console.WriteLine(mInfos.CreatureGenericId);
            }
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                Clear();
                _fighters = null;
                _allies = null;
                _ennemies = null;
                _effectsDurations = null;
                _spellsIntervals = null;
                _totalSpellLaunchs = null;
                _totalSpellLaunchsInCells = null;
                PositionsForChallengers = null;
                PositionsForDefenders = null;
                Options = null;
                _account = null;

                _disposedValue = true;
            }
        }

        ~FightGame() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }
}
