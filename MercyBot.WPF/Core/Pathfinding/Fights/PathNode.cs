namespace MercyBot.Core.Pathfinding.Fights
{
    public class PathNode
    {

        // Properties
        public short CellId { get; private set; }
        public int AvailableMp { get; private set; }
        public int AvailableAp { get; private set; }
        public int TackleMp { get; private set; }
        public int TackleAp { get; private set; }
        public int Distance { get; private set; }


        // Constructor
        public PathNode(short cellId, int mp, int ap, int tackleMp, int tackleAp, int distance)
        {
            CellId = cellId;
            AvailableMp = mp;
            AvailableAp = ap;
            TackleMp = tackleMp;
            TackleAp = tackleAp;
            Distance = distance;
        }

    }
}
