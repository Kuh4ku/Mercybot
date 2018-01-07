using System.Collections.Generic;

namespace MercyBot.Protocol.Data.Maps
{
    public class Map
    {

        // Properties
        public int Id { get; set; }
        public int TopNeighbourId { get; set; }
        public int BottomNeighbourId { get; set; }
        public int LeftNeighbourId { get; set; }
        public int RightNeighbourId { get; set; }
        public List<Cell> Cells { get; set; }
        public Dictionary<short, List<dynamic>> MidgroundLayer { get; set; }


        // Constructor
        internal Map() { }

    }
}
