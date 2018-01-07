using System;
using System.Collections.Generic;
using System.Linq;

namespace MercyBot.Core.Pathfinding
{
    public class MapPoint
    {

        // Fields
        public static List<MapPoint> cells;


        // Properties
        public int X { get; internal set; }
        public int Y { get; internal set; }
        public short CellId { get; private set; }


        // Constructor
        static MapPoint()
        {
            cells = new List<MapPoint>();

            int row, x, y;
            for (short i = 0; i < 560; i++)
            {
                row = i % 14 - ~~(i / 28);
                x = row + 19;
                y = row + ~~(i / 14);
                cells.Add(new MapPoint()
                {
                    X = x,
                    Y = y,
                    CellId = i
                });
            }
        }


        public int DistanceTo(MapPoint destination) => (int)Math.Round(Math.Sqrt(Math.Pow(destination.X - X, 2) + Math.Pow(destination.Y - Y, 2)));
        public int DistanceToCell(MapPoint destination) => Math.Abs(X - destination.X) + Math.Abs(Y - destination.Y);


        public static MapPoint FromCellId(short cellId) => cells[cellId];
        public static MapPoint FromCoords(int x, int y) => cells.FirstOrDefault(c => c.X == x && c.Y == y);

        public static List<MapPoint> GetNeighbourCells(short cellId, bool allowDiagonal)
        {
            var coord = FromCellId(cellId);
            var neighbours = new List<MapPoint>();

            if (allowDiagonal) { neighbours.Add(FromCoords(coord.X + 1, coord.Y + 1)); }
            neighbours.Add(FromCoords(coord.X, coord.Y + 1));
            if (allowDiagonal) { neighbours.Add(FromCoords(coord.X - 1, coord.Y + 1)); }
            neighbours.Add(FromCoords(coord.X - 1, coord.Y));
            if (allowDiagonal) { neighbours.Add(FromCoords(coord.X - 1, coord.Y - 1)); }
            neighbours.Add(FromCoords(coord.X, coord.Y - 1));
            if (allowDiagonal) { neighbours.Add(FromCoords(coord.X + 1, coord.Y - 1)); }
            neighbours.Add(FromCoords(coord.X + 1, coord.Y));

            return neighbours;
        }

    }
}
