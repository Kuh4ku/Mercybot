namespace MercyBot.Core.Pathfinding
{
    public class CellData
    {

        // Properties
        public int I { get; private set; }
        public int J { get; private set; }
        public short Floor { get; internal set; }
        public short Zone { get; internal set; }
        public double Speed { get; internal set; }
        public double Weight { get; internal set; }
        public CellPath CandidateRef { get; internal set; }


        // Constructor
        internal CellData(int i, int j)
        {
            I = i;
            J = j;
        }

    }
}
