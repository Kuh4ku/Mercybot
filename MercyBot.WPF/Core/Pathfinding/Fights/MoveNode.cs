namespace MercyBot.Core.Pathfinding.Fights
{
    public class MoveNode
    {

        // Properties
        public int Ap { get; private set; }
        public int Mp { get; private set; }
        public short From { get; private set; }
        public bool Reachable { get; private set; }
        public FightPath Path { get; set; }


        // Constructor
        public MoveNode(int ap, int mp, short from, bool reachable)
        {
            Ap = ap;
            Mp = mp;
            From = from;
            Reachable = reachable;
        }

    }
}
