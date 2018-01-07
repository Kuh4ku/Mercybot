using MercyBot.Core.Accounts.Extensions.Fights.Configuration;
using MercyBot.Core.Accounts.Extensions.Fights.Configuration.Enums;
using MercyBot.Core.Accounts.InGame.Fights;
using MercyBot.Core.Accounts.InGame.Fights.Fighters;
using MercyBot.Core.Pathfinding;
using MercyBot.Core.Pathfinding.Fights;
using MercyBot.Protocol.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MercyBot.Configurations.Language;

namespace MercyBot.Core.Accounts.Extensions.Fights
{
    public class SpellsManager : IDisposable
    {

        // Fields
        private Account _account;
        private int _spellIdToCast;
        private short _targetCellId;
        private byte _ennemiesTouched;


        // Constructor
        public SpellsManager(Account account)
        {
            _account = account;
            _spellIdToCast = -1;
            _targetCellId = -1;
        }


        public async Task<SpellCastingResults> ManageSpell(Spell spell)
        {
            // Check if we have an AOE spell we need to cast
            if (_spellIdToCast != -1 && _spellIdToCast == spell.SpellId)
            {
                _account.Logger.LogDebug(LanguageManager.Translate("52"), LanguageManager.Translate("62", spell.SpellName, _ennemiesTouched, _targetCellId));
                await _account.Game.Fight.LaunchSpell(spell.SpellId, _targetCellId);

                _spellIdToCast = -1;
                _targetCellId = -1;
                _ennemiesTouched = 0;

                return SpellCastingResults.CASTED;
            }

            // Check for the distance
            if (!IsDistanceGood(spell))
                return SpellCastingResults.NOT_CASTED;

            // In case its a spell we need to cast at a specific hp percentage
            if (_account.Game.Fight.PlayedFighter.LifePercent > spell.CharacterHp)
                return SpellCastingResults.NOT_CASTED;

            // Simple spell
            if (spell.Target == SpellTargets.EMPTY_CELL)
            {
                return (await CastSpellOnEmptyCell(spell));
            }

            if (!spell.HandToHand && !spell.AOE)
            {
                return (await CastSimpleSpell(spell));
            }

            // HandToHand Spell and we're h2h with someone
            if (spell.HandToHand && !spell.AOE && _account.Game.Fight.IsHandToHandWithAnEnnemy())
            {
                return (await CastSimpleSpell(spell));
            }

            // HandToHand spell and we're not h2h with someone
            if (spell.HandToHand && !spell.AOE && !_account.Game.Fight.IsHandToHandWithAnEnnemy())
            {
                return (await MoveToCastSimpleSpell(spell, GetNearestTarget(spell)));
            }

            // AOE spell (even HandToHand)
            if (spell.AOE)
            {
                return (await CastAOESpell(spell));
            }

            return SpellCastingResults.NOT_CASTED;
        }

        private async Task<SpellCastingResults> CastAOESpell(Spell spell)
        {
            if (spell.Target == SpellTargets.ALLY || spell.Target == SpellTargets.EMPTY_CELL)
                return SpellCastingResults.NOT_CASTED;

            if (_account.Game.Fight.CanLaunchSpell(spell.SpellId) != SpellInabilityReasons.NONE)
                return SpellCastingResults.NOT_CASTED;

            var spellEntry = _account.Game.Character.GetSpell(spell.SpellId);
            Spells spellData = DataManager.Get<Spells>(spell.SpellId);
            SpellLevels spellLevel = DataManager.Get<SpellLevels>(spellData.SpellLevels[spellEntry.Level - 1]);

            // Get all the possible ranges
            Stopwatch sw = Stopwatch.StartNew();
            List<RangeNodeEntry> entries = new List<RangeNodeEntry>();
            RangeNodeEntry entry;

            // Include our current cell
            entry = GetRangeNodeEntry(_account.Game.Fight.PlayedFighter.CellId, null, spell, spellLevel);
            if (entry.TouchedEnnemiesByCell.Count > 0)
            {
                entries.Add(entry);
            }

            foreach (var kvp in FightsPathfinder.GetReachableZone(_account.Game.Fight, _account.Game.Map.Data, _account.Game.Fight.PlayedFighter.CellId))
            {
                if (!kvp.Value.Reachable)
                    continue;

                if (kvp.Value.Ap > 0 || kvp.Value.Mp > 0)
                    continue;

                entry = GetRangeNodeEntry(kvp.Key, kvp.Value, spell, spellLevel);
                if (entry.TouchedEnnemiesByCell.Count > 0)
                {
                    entries.Add(entry);
                }
            }

            // Get a cell where we can hit the most
            // If we need to move, try to move with the least amount of mps (with the same number of touched ennemies of course)
            short cellId = -1;
            short fromCellId = -1;
            KeyValuePair<short, MoveNode>? node = null;
            byte touchedEnnemies = 0;
            int usedMps = 99;

            for (int i = 0; i < entries.Count; i++)
            {
                foreach (var kvp in entries[i].TouchedEnnemiesByCell)
                {
                    // Check for HandToHand
                    if (spell.HandToHand && !_account.Game.Fight.IsHandToHandWithAnEnnemy(entries[i].FromCellId))
                        continue;

                    // Check if we can cast the spell first
                    if (_account.Game.Fight.CanLaunchSpell(spell.SpellId, entries[i].FromCellId, kvp.Key) != SpellInabilityReasons.NONE)
                        continue;

                    // >= in case a cell uses less pm
                    if (kvp.Value >= touchedEnnemies)
                    {
                        // If its the same number of touched ennemies, check for the amount of mp we will use
                        //if (kvp.Value > touchedEnnemies || (kvp.Value == touchedEnnemies && entries[i].MpUsed < usedMps))
                        if (kvp.Value > touchedEnnemies || (kvp.Value == touchedEnnemies && entries[i].MpUsed <= usedMps))
                        {
                            touchedEnnemies = kvp.Value;
                            cellId = kvp.Key;
                            fromCellId = entries[i].FromCellId;
                            usedMps = entries[i].MpUsed;
                            if (entries[i].Node != null)
                            {
                                node = new KeyValuePair<short, MoveNode>(fromCellId, entries[i].Node);
                            }
                        }
                    }
                }
            }

            if (cellId != -1)
            {
                // If node is null, it means that the chosen cellId is within range, so we don't have to move
                if (node == null)
                {
                    _account.Logger.LogDebug(LanguageManager.Translate("52"), LanguageManager.Translate("62", spell.SpellName, touchedEnnemies, cellId));
                    await _account.Game.Fight.LaunchSpell(spell.SpellId, cellId);
                    return SpellCastingResults.CASTED;
                }
                // We need to move
                else
                {
                    _account.Logger.LogDebug(LanguageManager.Translate("52"), LanguageManager.Translate("63", fromCellId, spell.SpellName));

                    // Set the spell to cast
                    _spellIdToCast = spell.SpellId;
                    _targetCellId = cellId;
                    _ennemiesTouched = touchedEnnemies;

                    await _account.Game.Managers.Movements.MoveToCellInFight(node);
                    return SpellCastingResults.MOVED;
                }
            }

            return SpellCastingResults.NOT_CASTED;
        }

        private RangeNodeEntry GetRangeNodeEntry(short fromCellId, MoveNode node, Spell spell, SpellLevels spellLevel)
        {
            // Calculate touched ennemies for every cell in SpellRange
            Dictionary<short, byte> touchedEnnemiesByCell = new Dictionary<short, byte>();
            var range = _account.Game.Fight.GetSpellRange(fromCellId, spellLevel);

            for (int i = 0; i < range.Count; i++)
            {
                byte tec = GetTouchedEnnemiesCount(fromCellId, range[i], spell, spellLevel);
                if (tec > 0)
                {
                    touchedEnnemiesByCell.Add(range[i], tec);
                }
            }

            return new RangeNodeEntry(fromCellId, touchedEnnemiesByCell, node);
        }

        private byte GetTouchedEnnemiesCount(short fromCellId, short targetCellId, Spell spell, SpellLevels spellLevel)
        {
            byte n = 0;

            var zone = _account.Game.Fight.GetSpellZone(spell.SpellId, fromCellId, targetCellId, spellLevel);

            if (zone != null)
            {
                for (int i = 0; i < zone.Count; i++)
                {
                    // Check self
                    if (spell.CarefulAOE && zone[i].CellId == fromCellId)
                        return 0;

                    // Check ally
                    if (spell.AvoidAllies)
                    {
                        foreach (var ally in _account.Game.Fight.Allies)
                        {
                            if (ally.CellId == zone[i].CellId)
                                return 0;
                        }
                    }

                    foreach (var ennemy in _account.Game.Fight.Ennemies)
                    {
                        if (ennemy.CellId == zone[i].CellId)
                        {
                            n++;
                        }
                    }
                }
            }

            return n;
        }

        private async Task<SpellCastingResults> CastSimpleSpell(Spell spell)
        {
            if (_account.Game.Fight.CanLaunchSpell(spell.SpellId) != SpellInabilityReasons.NONE)
                return SpellCastingResults.NOT_CASTED;

            var target = GetNearestTarget(spell);

            if (target != null)
            {
                var sir = _account.Game.Fight.CanLaunchSpell(spell.SpellId, _account.Game.Fight.PlayedFighter.CellId, target.CellId);

                if (sir == SpellInabilityReasons.NONE)
                {
                    _account.Logger.LogDebug(LanguageManager.Translate("52"), LanguageManager.Translate("64", spell.SpellName, target.CellId));
                    await _account.Game.Fight.LaunchSpell(spell.SpellId, target.CellId);
                    return SpellCastingResults.CASTED;
                }

                if (sir == SpellInabilityReasons.NOT_IN_RANGE)
                {
                    return (await MoveToCastSimpleSpell(spell, target));
                }
            }
            // A spell on an empty cell is a LanguageManager.Translate("65") case
            else if (spell.Target == SpellTargets.EMPTY_CELL)
            {
                return (await CastSpellOnEmptyCell(spell));
            }

            return SpellCastingResults.NOT_CASTED;
        }

        private async Task<SpellCastingResults> MoveToCastSimpleSpell(Spell spell, FighterEntry target)
        {
            // We'll move to cast the spell (if we can) with the least number of MP possible
            KeyValuePair<short, MoveNode>? node = null;
            int pmUsed = 99;

            foreach (var kvp in FightsPathfinder.GetReachableZone(_account.Game.Fight, _account.Game.Map.Data, _account.Game.Fight.PlayedFighter.CellId))
            {
                if (!kvp.Value.Reachable)
                    continue;

                // Only choose the safe paths
                // TODO: Maybe in the futur try to cast the spell even with tackle cost, in a LanguageManager.Translate("66") way of course
                if (kvp.Value.Path.Ap > 0 || kvp.Value.Path.Mp > 0)
                    continue;

                if (spell.HandToHand && !_account.Game.Fight.IsHandToHandWithAnEnnemy(kvp.Key))
                    continue;

                if (_account.Game.Fight.CanLaunchSpell(spell.SpellId, kvp.Key, target.CellId) != SpellInabilityReasons.NONE)
                    continue;

                if (kvp.Value.Path.Reachable.Count <= pmUsed)
                {
                    node = kvp;
                    pmUsed = kvp.Value.Path.Reachable.Count;
                }
            }

            if (node != null)
            {
                _account.Logger.LogDebug(LanguageManager.Translate("52"), LanguageManager.Translate("63", node.Value.Key, spell.SpellName));
                await _account.Game.Managers.Movements.MoveToCellInFight(node);
                return SpellCastingResults.MOVED;
            }

            return SpellCastingResults.NOT_CASTED;
        }

        private async Task<SpellCastingResults> CastSpellOnEmptyCell(Spell spell)
        {
            if (_account.Game.Fight.CanLaunchSpell(spell.SpellId) != SpellInabilityReasons.NONE)
                return SpellCastingResults.NOT_CASTED;

            // In case we need to cast the spell on an empty case next to the character but all of them are taken
            if (spell.Target == SpellTargets.EMPTY_CELL && _account.Game.Fight.GetHandToHandEnnemies().Count() == 4)
                return SpellCastingResults.NOT_CASTED;

            var spellEntry = _account.Game.Character.GetSpell(spell.SpellId);
            Spells spellData = DataManager.Get<Spells>(spell.SpellId);
            SpellLevels spellLevel = DataManager.Get<SpellLevels>(spellData.SpellLevels[spellEntry.Level - 1]);

            var range = _account.Game.Fight.GetSpellRange(_account.Game.Fight.PlayedFighter.CellId, spellLevel);
            for (int i = 0; i < range.Count; i++)
            {
                if (_account.Game.Fight.CanLaunchSpell(spell.SpellId, _account.Game.Fight.PlayedFighter.CellId, range[i]) == SpellInabilityReasons.NONE)
                {
                    if (spell.HandToHand && MapPoint.FromCellId(range[i]).DistanceToCell(MapPoint.FromCellId(_account.Game.Fight.PlayedFighter.CellId)) != 1)
                        continue;

                    _account.Logger.LogDebug(LanguageManager.Translate("52"), LanguageManager.Translate("64", spell.SpellName, range[i]));
                    await _account.Game.Fight.LaunchSpell(spell.SpellId, range[i]);
                    return SpellCastingResults.CASTED;
                }
            }

            // We need to move
            return (await MoveToCastSpellOnEmptyCell(spell, spellLevel));
        }

        private async Task<SpellCastingResults> MoveToCastSpellOnEmptyCell(Spell spell, SpellLevels spellLevel)
        {
            // We'll move to cast the spell (if we can) with the least number of MP possible
            KeyValuePair<short, MoveNode>? node = null;
            int pmUsed = 99;

            foreach (var kvp in FightsPathfinder.GetReachableZone(_account.Game.Fight, _account.Game.Map.Data, _account.Game.Fight.PlayedFighter.CellId))
            {
                if (!kvp.Value.Reachable)
                    continue;

                // Only choose the safe paths
                // TODO: Maybe in the futur try to cast the spell even with tackle cost, in a LanguageManager.Translate("66") way of course
                if (kvp.Value.Path.Ap > 0 || kvp.Value.Path.Mp > 0)
                    continue;

                //if (spell.HandToHand && MapPoint.FromCellId(kvp.Key).DistanceToCell(MapPoint.FromCellId())
                //    continue;

                var range = _account.Game.Fight.GetSpellRange(kvp.Key, spellLevel);
                for (int i = 0; i < range.Count; i++)
                {
                    if (_account.Game.Fight.CanLaunchSpell(spell.SpellId, kvp.Key, range[i]) != SpellInabilityReasons.NONE)
                        continue;

                    if (kvp.Value.Path.Reachable.Count < pmUsed)
                    {
                        node = kvp;
                        pmUsed = kvp.Value.Path.Reachable.Count;
                    }
                }
            }

            if (node != null)
            {
                _account.Logger.LogDebug(LanguageManager.Translate("52"), LanguageManager.Translate("63", node.Value.Key, spell.SpellName));
                await _account.Game.Managers.Movements.MoveToCellInFight(node);
                return SpellCastingResults.MOVED;
            }

            return SpellCastingResults.NOT_CASTED;
        }

        private FighterEntry GetNearestTarget(Spell spell)
        {
            if (spell.Target == SpellTargets.SELF)
                return _account.Game.Fight.PlayedFighter;

            if (spell.Target == SpellTargets.EMPTY_CELL)
                return null; // Assuming that the others never return null

            bool Filter(FighterEntry fighter)
            {
                // In case the user wants to ignore invocations
                if (_account.Extensions.Fights.Configuration.IgnoreSummonedEnnemies && fighter.Stats.Summoned)
                    return false;

                return fighter.LifePercent <= spell.TargetHp && IsResistanceGood(spell, fighter);
            }

            return spell.Target == SpellTargets.ENNEMY ?
                _account.Game.Fight.GetNearestEnnemy(-1, Filter) :
                _account.Game.Fight.GetNearestAlly(Filter);
        }

        private bool IsDistanceGood(Spell spell)
        {
            // This option is ignored when the value is 0
            if (spell.DistanceToClosestMonster == 0)
                return true;

            var nearestEnnemy = _account.Game.Fight.GetNearestEnnemy();
            
            if (nearestEnnemy == null)
                return false;

            MapPoint mp = MapPoint.FromCellId(nearestEnnemy.CellId);
            return MapPoint.FromCellId(_account.Game.Fight.PlayedFighter.CellId).DistanceToCell(mp) <= spell.DistanceToClosestMonster;
        }

        private bool IsResistanceGood(Spell spell, FighterEntry fighter)
        {
            switch (spell.Resistance)
            {
                case SpellResistances.NEUTRAL:
                    return fighter.Stats.NeutralElementResistPercent <= spell.ResistanceValue;
                case SpellResistances.EARTH:
                    return fighter.Stats.EarthElementResistPercent <= spell.ResistanceValue;
                case SpellResistances.FIRE:
                    return fighter.Stats.FireElementResistPercent <= spell.ResistanceValue;
                case SpellResistances.WIND:
                    return fighter.Stats.AirElementResistPercent <= spell.ResistanceValue;
                default: // Water
                    return fighter.Stats.WaterElementResistPercent <= spell.ResistanceValue;
            }
        }

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }

                _account = null;

                disposedValue = true;
            }
        }

        ~SpellsManager() => Dispose(false);

        public void Dispose() => Dispose(true);

        #endregion

    }

    internal struct RangeNodeEntry
    {

        // Properties
        public short FromCellId { get; private set; }
        public Dictionary<short, byte> TouchedEnnemiesByCell { get; private set; }
        public MoveNode Node { get; private set; }

        public int MpUsed => Node?.Path.Reachable.Count ?? 0;

        // Constructor
        internal RangeNodeEntry(short fromCellId, Dictionary<short, byte> touchedEnnemiesByCell, MoveNode node)
        {
            FromCellId = fromCellId;
            TouchedEnnemiesByCell = touchedEnnemiesByCell;
            Node = node;
        }

    }

}
