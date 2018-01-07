using System;
using System.Collections.Generic;
using System.Linq;

namespace MercyBot.Core.Pathfinding.Shapes.Zones
{
    public static class Shaper
    {

        public static Dictionary<char, ShaperEntry> ShaperMap = new Dictionary<char, ShaperEntry>()
        {
            { 'P', null },
            { 'A', null },
            { 'D', null },
            { 'X', new ShaperEntry(ShapeCross, false, false) },
            { 'L', new ShaperEntry(ShapeLine, true, false) },
            { 'T', new ShaperEntry(ShapePerpendicular,true, false) },
            { 'C', new ShaperEntry(ShapeRing, false, false) },
            { 'O', new ShaperEntry(ShapeCirclePerimeter, false, false) },
            { '+', new ShaperEntry(ShapeStar, false, false) },
            { 'G', new ShaperEntry(ShapeSquare, false, false) },
            { 'V', new ShaperEntry(ShapeCone, true, false) },
            { 'W', new ShaperEntry(ShapeCones, false, false) },
            { '/', new ShaperEntry(ShapeLine, true, false) },
            { '-', new ShaperEntry(ShapePerpendicular, true, false) },
            { 'U', new ShaperEntry(ShapeHalfcircle, true, false) },
            { 'Q', new ShaperEntry(ShapeCross, false, true) },
            { '#', new ShaperEntry(ShapeStar, false, true) },
            { '*', new ShaperEntry(ShapeCrossAndStar, false, false) },
            { 'I', new ShaperEntry(ShapeInvertedCircle, false, false) }
        };

        public static IEnumerable<MapPoint> ShapeRing(int x, int y, int radiusMin, int radiusMax, int dirX = 0, int dirY = 0)
        {
            List<MapPoint> range = new List<MapPoint>();

            if (radiusMin == 0) range.Add(MapPoint.FromCoords(x, y));
            for (int radius = (radiusMin == 0 ? 1 : radiusMin); radius <= radiusMax; radius++)
            {
                for (int i = 0; i < radius; i++)
                {
                    int r = radius - i;
                    range.Add(MapPoint.FromCoords(x + i, y - r));
                    range.Add(MapPoint.FromCoords(x + r, y + i));
                    range.Add(MapPoint.FromCoords(x - i, y + r));
                    range.Add(MapPoint.FromCoords(x - r, y - i));
                }
            }

            return range.Where(c => c != null);
        }

        public static IEnumerable<MapPoint> ShapeCross(int x, int y, int radiusMin, int radiusMax, int dirX = 0, int dirY = 0)
        {
            List<MapPoint> range = new List<MapPoint>();

            if (radiusMin == 0) range.Add(MapPoint.FromCoords(x, y));
            for (int i = (radiusMin == 0 ? 1 : radiusMin); i <= radiusMax; i++)
            {
                range.Add(MapPoint.FromCoords(x - i, y));
                range.Add(MapPoint.FromCoords(x + i, y));
                range.Add(MapPoint.FromCoords(x, y - i));
                range.Add(MapPoint.FromCoords(x, y + i));
            }

            return range.Where(c => c != null);
        }

        public static IEnumerable<MapPoint> ShapeStar(int x, int y, int radiusMin, int radiusMax, int dirX = 0, int dirY = 0)
        {
            List<MapPoint> range = new List<MapPoint>();

            if (radiusMin == 0) range.Add(MapPoint.FromCoords(x, y));
            for (int i = (radiusMin == 0 ? 1 : radiusMin); i <= radiusMax; i++)
            {
                range.Add(MapPoint.FromCoords(x - i, y - i));
                range.Add(MapPoint.FromCoords(x - i, y + i));
                range.Add(MapPoint.FromCoords(x + i, y - i));
                range.Add(MapPoint.FromCoords(x + i, y + i));
            }

            return range.Where(c => c != null);
        }

        public static IEnumerable<MapPoint> ShapeCrossAndStar(int x, int y, int radiusMin, int radiusMax, int dirX = 0, int dirY = 0)
        {
            List<MapPoint> range = new List<MapPoint>();

            if (radiusMin == 0) range.Add(MapPoint.FromCoords(x, y));
            for (int i = (radiusMin == 0 ? 1 : radiusMin); i <= radiusMax; i++)
            {
                range.Add(MapPoint.FromCoords(x - i, y));
                range.Add(MapPoint.FromCoords(x + i, y));
                range.Add(MapPoint.FromCoords(x, y - i));
                range.Add(MapPoint.FromCoords(x, y + i));

                range.Add(MapPoint.FromCoords(x - i, y - i));
                range.Add(MapPoint.FromCoords(x - i, y + i));
                range.Add(MapPoint.FromCoords(x + i, y - i));
                range.Add(MapPoint.FromCoords(x + i, y + i));
            }

            return range.Where(c => c != null);
        }

        public static IEnumerable<MapPoint> ShapeSquare(int x, int y, int radiusMin, int radiusMax, int dirX = 0, int dirY = 0)
        {
            List<MapPoint> range = new List<MapPoint>();

            if (radiusMin == 0) range.Add(MapPoint.FromCoords(x, y));
            for (var radius = (radiusMin == 0 ? 1 : radiusMin); radius <= radiusMax; radius++)
            {
                range.Add(MapPoint.FromCoords(x - radius, y));
                range.Add(MapPoint.FromCoords(x + radius, y));
                range.Add(MapPoint.FromCoords(x, y - radius));
                range.Add(MapPoint.FromCoords(x, y + radius));

                range.Add(MapPoint.FromCoords(x - radius, y - radius));
                range.Add(MapPoint.FromCoords(x - radius, y + radius));
                range.Add(MapPoint.FromCoords(x + radius, y - radius));
                range.Add(MapPoint.FromCoords(x + radius, y + radius));

                for (var i = 1; i < radius; i++)
                {
                    range.Add(MapPoint.FromCoords(x + radius, y + i));
                    range.Add(MapPoint.FromCoords(x + radius, y - i));
                    range.Add(MapPoint.FromCoords(x - radius, y + i));
                    range.Add(MapPoint.FromCoords(x - radius, y - i));
                    range.Add(MapPoint.FromCoords(x + i, y + radius));
                    range.Add(MapPoint.FromCoords(x - i, y + radius));
                    range.Add(MapPoint.FromCoords(x + i, y - radius));
                    range.Add(MapPoint.FromCoords(x - i, y - radius));
                }
            }

            return range.Where(c => c != null);
        }

        public static IEnumerable<MapPoint> ShapeCone(int x, int y, int radiusMin, int radiusMax, int dirX = 0, int dirY = 0)
        {
            List<MapPoint> range = new List<MapPoint>();

            for (var radius = radiusMin; radius <= radiusMax; radius++)
            {
                var xx = x + radius * dirX;
                var yy = y + radius * dirY;
                range.Add(MapPoint.FromCoords(xx, yy));

                for (var i = 1; i <= radius; i++)
                {
                    range.Add(MapPoint.FromCoords(xx + i * dirY, yy - i * dirX));
                    range.Add(MapPoint.FromCoords(xx - i * dirY, yy + i * dirX));
                }
            }

            return range.Where(c => c != null);
        }

        public static IEnumerable<MapPoint> ShapeHalfcircle(int x, int y, int radiusMin, int radiusMax, int dirX = 0, int dirY = 0)
        {
            List<MapPoint> range = new List<MapPoint>();

            if (radiusMin == 0) range.Add(MapPoint.FromCoords(x, y));
            for (var radius = (radiusMin == 0 ? 1 : radiusMin); radius <= radiusMax; radius++)
            {
                var xx = x - radius * dirX;
                var yy = y - radius * dirY;
                range.Add(MapPoint.FromCoords(xx + radius * dirY, yy - radius * dirX));
                range.Add(MapPoint.FromCoords(xx - radius * dirY, yy + radius * dirX));
            }

            return range.Where(c => c != null);
        }

        public static IEnumerable<MapPoint> ShapeCones(int x, int y, int radiusMin, int radiusMax, int dirX = 0, int dirY = 0)
        {
            List<MapPoint> range = new List<MapPoint>();

            for (var radius = (radiusMin == 0 ? 1 : radiusMin); radius <= radiusMax; radius++)
            {
                range.Add(MapPoint.FromCoords(x - radius, y));
                range.Add(MapPoint.FromCoords(x + radius, y));
                range.Add(MapPoint.FromCoords(x, y - radius));
                range.Add(MapPoint.FromCoords(x, y + radius));

                for (var i = 1; i < radius; i++)
                {
                    range.Add(MapPoint.FromCoords(x + radius, y + i));
                    range.Add(MapPoint.FromCoords(x + radius, y - i));
                    range.Add(MapPoint.FromCoords(x - radius, y + i));
                    range.Add(MapPoint.FromCoords(x - radius, y - i));
                    range.Add(MapPoint.FromCoords(x + i, y + radius));
                    range.Add(MapPoint.FromCoords(x - i, y + radius));
                    range.Add(MapPoint.FromCoords(x + i, y - radius));
                    range.Add(MapPoint.FromCoords(x - i, y - radius));
                }
            }

            return range.Where(c => c != null);
        }

        public static IEnumerable<MapPoint> ShapeLine(int x, int y, int radiusMin, int radiusMax, int dirX = 0, int dirY = 0)
        {
            List<MapPoint> range = new List<MapPoint>();

            for (var i = radiusMin; i <= radiusMax; i++)
            {
                range.Add(MapPoint.FromCoords(x + dirX * i, y + dirY * i));
            }

            return range.Where(c => c != null);
        }

        public static IEnumerable<MapPoint> ShapeCirclePerimeter(int x, int y, int radiusMin, int radiusMax, int dirX = 0, int dirY = 0)
            => ShapeRing(x, y, radiusMax, radiusMax);

        public static IEnumerable<MapPoint> ShapeInvertedCircle(int x, int y, int radiusMin, int radiusMax, int dirX = 0, int dirY = 0)
            => ShapeRing(x, y, radiusMax, 39);

        public static IEnumerable<MapPoint> ShapePerpendicular(int x, int y, int radiusMin, int radiusMax, int dirX = 0, int dirY = 0)
        {
            List<MapPoint> range = new List<MapPoint>();

            if (radiusMin == 0) range.Add(MapPoint.FromCoords(x, y));
            for (var i = (radiusMin == 0 ? 1 : radiusMin); i <= radiusMax; i++)
            {
                range.Add(MapPoint.FromCoords(x + dirY * i, y - dirX * i));
                range.Add(MapPoint.FromCoords(x - dirY * i, y + dirX * i));
            }

            return range.Where(c => c != null);
        }

        /*
            var shaperMap = {
		        'P': null, // Point: displayed as one cell.
		        'A': null, // Whole map: displayed as one cell.
		        'D': null, // Chessboard mask: not implemented in original game.
		        'X': { fn: shapeCross,           hasDirection: false, withoutCenter: false },
		        'L': { fn: shapeLine,            hasDirection: true,  withoutCenter: false },
		        'T': { fn: shapePerpendicular,   hasDirection: true,  withoutCenter: false },
		        'C': { fn: shapeRing,            hasDirection: false, withoutCenter: false },
		        'O': { fn: shapeCirclePerimeter, hasDirection: false, withoutCenter: false },
		        '+': { fn: shapeStar,            hasDirection: false, withoutCenter: false },
		        'G': { fn: shapeSquare,          hasDirection: false, withoutCenter: false },
		        'V': { fn: shapeCone,            hasDirection: true,  withoutCenter: false },
		        'W': { fn: shapeCones,           hasDirection: false, withoutCenter: false },
		        '/': { fn: shapeLine,            hasDirection: true,  withoutCenter: false },
		        '-': { fn: shapePerpendicular,   hasDirection: true,  withoutCenter: false },
		        'U': { fn: shapeHalfcircle,      hasDirection: true,  withoutCenter: false },
		        'Q': { fn: shapeCross,           hasDirection: false, withoutCenter: true },
		        '#': { fn: shapeStar,            hasDirection: false, withoutCenter: true },
		        '*': { fn: shapeCrossAndStar,    hasDirection: false, withoutCenter: false },
		        'I': { fn: shapeInvertedCircle,  hasDirection: false, withoutCenter: false }
	        };
        */

    }

    public class ShaperEntry
    {

        // Properties
        //x, y, radiusMin, radiusMax, dirX, dirY
        public Func<int, int, int, int, int, int, IEnumerable<MapPoint>> Fn { get; private set; }
        public bool HasDirection { get; private set; }
        public bool WithoutCenter { get; private set; }


        // Constructor
        internal ShaperEntry(Func<int, int, int, int, int, int, IEnumerable<MapPoint>> fn, bool hasDirection, bool withoutCenter)
        {
            Fn = fn;
            HasDirection = hasDirection;
            WithoutCenter = withoutCenter;
        }

    }

}
