using MercyBot.Utility.DofusTouch;
using System;

namespace MercyBot.Utility.Extensions
{
    public static class SpecialExtensions
    {

        public static bool TryGetCoord(this int cellid, out float x, out float y) => TryGetCoord((short)cellid, out x, out y);
        public static bool TryGetCoord(this short cellid, out float x, out float y)
        {
            x = 0;
            y = 0;

            if (cellid < 0 || cellid > 560)
                return false;

            x = cellid % DTConstants.MAP_WIDTH;
            y = (float)Math.Floor((float)cellid / DTConstants.MAP_WIDTH);
            return true;
        }

    }
}
