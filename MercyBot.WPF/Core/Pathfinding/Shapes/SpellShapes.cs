using MercyBot.Core.Pathfinding.Shapes.Zones;
using MercyBot.Protocol.Data;
using MercyBot.Protocol.Data.Maps;
using System.Collections.Generic;
using System.Linq;

namespace MercyBot.Core.Pathfinding.Shapes
{
    public static class SpellShapes
    {

        public static IEnumerable<MapPoint> GetSpellRange(short sourceCellId, SpellLevels spellLevel, int additionalRange = 0)
        {
            var mp = MapPoint.FromCellId(sourceCellId);
            int range = spellLevel.Range + (spellLevel.RangeCanBeBoosted ? additionalRange : 0);

            if (spellLevel.CastInLine && spellLevel.CastInDiagonal)
            {
                return Shaper.ShapeCross(mp.X, mp.Y, spellLevel.MinRange, range)
                    .Union(Shaper.ShapeStar(mp.X, mp.Y, spellLevel.MinRange, range));
            }
            else if (spellLevel.CastInDiagonal)
            {
                return Shaper.ShapeStar(mp.X, mp.Y, spellLevel.MinRange, range);
            }
            else if (spellLevel.CastInLine)
            {
                return Shaper.ShapeCross(mp.X, mp.Y, spellLevel.MinRange, range);
            }
            else
            {
                return Shaper.ShapeRing(mp.X, mp.Y, spellLevel.MinRange, range);
            }
        }

        public static List<MapPoint> GetSpellEffectZone(Map map, SpellLevels spellLevel, short casterCellId, short targetCellId)
        {
            List<MapPoint> zone = new List<MapPoint>();

            Zone effect = GetZoneEffect(spellLevel);
            var shaper = Shaper.ShaperMap[effect.ZoneShape];

            if (shaper == null)
            {
                zone.Add(MapPoint.FromCellId(targetCellId));
                return zone;
            }

            var targetCoords = MapPoint.FromCellId(targetCellId);
            int dirX = 0, dirY = 0;

            if (shaper.HasDirection)
            {
                var casterCoords = MapPoint.FromCellId(casterCellId);
                dirX = targetCoords.X == casterCoords.X ? 0 : targetCoords.X > casterCoords.X ? 1 : -1;
                dirY = targetCoords.Y == casterCoords.Y ? 0 : targetCoords.Y > casterCoords.Y ? 1 : -1;
            }

            var radiusMin = shaper.WithoutCenter ? (effect.ZoneMinSize == 0 ? 1 : effect.ZoneMinSize): effect.ZoneMinSize;
            var rangeCoords = shaper.Fn(targetCoords.X, targetCoords.Y, radiusMin, effect.ZoneSize, dirX, dirY);

            foreach (var mp in rangeCoords)
            {
                if (map.Cells[mp.CellId].IsWalkable(true))
                {
                    zone.Add(mp);
                }
            }

            return zone;
        }

        private static Zone GetZoneEffect(SpellLevels spellLevel)
        {
            Zone zoneEffect = null;
            int ray = 63;

            for (int i = 0; i < spellLevel.Effects.Count; i++)
            {
                if (spellLevel.Effects[i]["rawZone"] != null)
                {
                    var ze = ZonesUtility.ParseZone(spellLevel.Effects[i]["rawZone"].ToString());
                    if (ze.ZoneSize > 0 && ze.ZoneSize < ray)
                    {
                        ray = ze.ZoneSize;
                        zoneEffect = ze;
                    }
                }
            }

            return (zoneEffect != null ? zoneEffect : ZonesUtility.ParseZone("P"));
        }

    }

}
