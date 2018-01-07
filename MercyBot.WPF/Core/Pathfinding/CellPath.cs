namespace MercyBot.Core.Pathfinding
{
    public class CellPath
    {

        // Properties
        public int I { get; internal set; }
        public int J { get; internal set; }
        public double W { get; internal set; }
        public double D { get; internal set; }
        public CellPath Path { get; internal set; }


        // Constructor
        internal CellPath(int i, int j, double w, double d, CellPath path)
        {
            I = i;
            J = j;
            W = w;
            D = d;
            Path = path;
        }

    }
}
