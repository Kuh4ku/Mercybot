namespace MercyBot.Protocol.Data.Maps
{
    public class Cell
    {

        // Properties
        public short l { get; set; }
        public short f { get; set; }
        public short c { get; set; }
        public short s { get; set; }
        public short z { get; set; }


        // Constructor
        internal Cell() { }


        public bool IsWalkable(bool isFightMode) => (l & (isFightMode ? 5 : 1)) == 1;
        public bool IsFarmCell() => (l & 32) == 32;
        public bool IsVisible() => (l & 64) == 64;
        public bool IsObstacle() => (l & 2) != 2;

    }
}
