using System.Collections.Generic;

namespace MercyBot.Core.Pathfinding.Fights
{
    public class FightPath
    {

        // Properties
        public List<short> Reachable { get; set; }
        public List<short> Unreachable { get; set; }
        public Dictionary<short, int> ReachableMap { get; set; }
        public Dictionary<short, int> UnreachableMap { get; set; }
        public int Ap { get; set; }
        public int Mp { get; set; }

    }
}
