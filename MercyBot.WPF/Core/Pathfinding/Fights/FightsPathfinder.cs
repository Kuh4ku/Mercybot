using MercyBot.Core.Accounts.InGame.Fights;
using MercyBot.Core.Accounts.InGame.Fights.Fighters;
using MercyBot.Protocol.Data.Maps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MercyBot.Core.Pathfinding.Fights
{
    public class FightsPathfinder
    {

        public static FightPath GetPath(short source, short target, Dictionary<short, MoveNode> zone)
        {
            if (!zone.ContainsKey(target))
                return null;

            var current = target;
            var reachable = new List<short>();
            var unreachable = new List<short>();
            var reachableMap = new Dictionary<short, int>();
            var unreachableMap = new Dictionary<short, int>();
            var ap = 0;
            var mp = 0;
            var distance = 0;

            while (current != source)
            {
                var cell = zone[current];
                if (cell.Reachable)
                {
                    reachable.Insert(0, current);
                    reachableMap.Add(current, distance);
                }
                else
                {
                    unreachable.Insert(0, current);
                    unreachableMap.Add(current, distance);
                }

                mp += cell.Mp;
                ap += cell.Ap;
                current = cell.From;
                distance += 1;
            }

            return new FightPath()
            {
                Reachable = reachable,
                Unreachable = unreachable,
                Ap = ap,
                Mp = mp,
                ReachableMap = reachableMap,
                UnreachableMap = unreachableMap,
            };
        }

        public static Dictionary<short, MoveNode> GetReachableZone(FightGame fight, Map map, short currentCellId)
        {
            Dictionary<short, MoveNode> zone = new Dictionary<short, MoveNode>();

            if (fight.PlayedFighter.MovementPoints <= 0)
                return zone;

            var maxDistance = fight.PlayedFighter.MovementPoints;

            List<PathNode> opened = new List<PathNode>();
            Dictionary<short, PathNode> closed = new Dictionary<short, PathNode>();

            var node = new PathNode(currentCellId, fight.PlayedFighter.MovementPoints, fight.PlayedFighter.ActionPoints, 0, 0, 1);
            opened.Add(node);
            closed[currentCellId] = node;

            while (opened.Count > 0)
            {
                var current = opened.Last();
                opened.Remove(current);
                var cellId = current.CellId;
                var neighbours = MapPoint.GetNeighbourCells(cellId, false);

                var tacklers = new List<FighterEntry>();
                int i = 0;
                while (i < neighbours.Count)
                {
                    var tackler = fight.Fighters.FirstOrDefault(f => f.CellId == neighbours[i]?.CellId);

                    if (neighbours[i] != null && tackler == null)
                    {
                        i++;
                        continue;
                    }

                    neighbours.RemoveAt(i);
                    if (tackler != null) tacklers.Add(tackler);
                }

                GetTackleCost(fight, tacklers, current.AvailableMp, current.AvailableAp, out int mpCost, out int apCost);
                var availableMp = current.AvailableMp - mpCost - 1;
                var availableAp = current.AvailableAp - apCost;
                var tackleMp = current.TackleMp + mpCost;
                var tackleAp = current.TackleAp + apCost;
                var distance = current.Distance + 1;
                var reachable = availableMp >= 0;

                // TODO: Handle marked cells

                for (i = 0; i < neighbours.Count; i++)
                {
                    if (closed.ContainsKey(neighbours[i].CellId))
                    {
                        var previous = closed[neighbours[i].CellId];
                        if (previous.AvailableMp > availableMp)
                            continue;

                        if (previous.AvailableMp == availableMp && previous.AvailableAp >= availableAp)
                            continue;
                    }

                    if (!map.Cells[neighbours[i].CellId].IsWalkable(true))
                        continue;

                    zone[neighbours[i].CellId] = new MoveNode(apCost, mpCost, cellId, reachable);
                    node = new PathNode(neighbours[i].CellId, availableMp, availableAp, tackleMp, tackleAp, distance);
                    closed[neighbours[i].CellId] = node;

                    if (current.Distance < maxDistance)
                    {
                        opened.Add(node);
                    }
                }
            }

            foreach (short cellKey in zone.Keys)
            {
                zone[cellKey].Path = GetPath(currentCellId, cellKey, zone);
            }

            return zone;
        }

        private static void GetTackleCost(FightGame fight, List<FighterEntry> tacklers, int mp, int ap, out int mpCost, out int apCost)
        {
            mp = Math.Max(0, mp);
            ap = Math.Max(0, ap);

            mpCost = 0;
            apCost = 0;

            if (!CanBeTackled(fight, fight.PlayedFighter) || tacklers.Count == 0)
                return;

            for (int i = 0; i < tacklers.Count; i++)
            {
                if (!tacklers[i].Alive)
                    continue;

                if (!CanBeTackler(tacklers[i], fight.PlayedFighter))
                    continue;

                var tackleRatio = GetTackleRatio(fight.PlayedFighter, tacklers[i]);

                if (tackleRatio >= 1)
                    continue;

                mpCost += (int)(mp * (1 - tackleRatio) + 0.5);
                apCost += (int)(ap * (1 - tackleRatio) + 0.5);
            }
        }

        private static bool CanBeTackler(FighterEntry tackler, FighterEntry actor)
        {
            if (tackler == null || actor == null)
                return false;

            if (!tackler.Alive || tackler.Stats.InvisibilityState != 3)
                return false;

            if (tackler.Team == actor.Team)
                return false;

            return true;
        }

        private static double GetTackleRatio(FighterEntry actor, FighterEntry tackler)
        {
            var evade = Math.Max(0, actor.Stats.TackleEvade);
            var block = Math.Max(0, tackler.Stats.TackleBlock);
            return ((double)evade + 2) / ((double)block + 2) / 2;
        }

        private static bool CanBeTackled(FightGame fight, FighterEntry actor)
        {
            if (actor.Stats.InvisibilityState != 3)
                return false;

            // TODO: Add carried condition

            if (fight.HasState(96) || fight.HasState(6))
                return false;

            return true;
        }

    }
}
