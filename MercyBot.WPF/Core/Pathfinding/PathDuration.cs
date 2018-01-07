using MercyBot.Utility.Extensions;
using System.Collections.Generic;

namespace MercyBot.Core.Pathfinding
{
    public static class PathDuration
    {

        // Fields
        private static readonly Dictionary<AnimDurationTypes, AnimDuration> _animDurations = new Dictionary<AnimDurationTypes, AnimDuration>()
        {
            { AnimDurationTypes.MOUNTED, new AnimDuration(135, 200, 120) },
            { AnimDurationTypes.PARABLE, new AnimDuration(400, 500, 450) },
            { AnimDurationTypes.RUNNING, new AnimDuration(170, 255, 150) },
            { AnimDurationTypes.WALKING, new AnimDuration(480, 510, 425) },
            { AnimDurationTypes.SLIDE, new AnimDuration(57, 85, 50) }
        };


        public static short Calculate(List<short> path, bool isFight = false, bool slide = false, bool riding = false)
        {
            short duration = 20; // TODO: Adding 20ms just in case, need tests to see if its gonna cause problems

            if (path.Count == 1)
                return duration;

            AnimDuration motionScheme;
            if (slide) motionScheme = _animDurations[AnimDurationTypes.SLIDE];
            else if (riding) motionScheme = _animDurations[AnimDurationTypes.MOUNTED];
            else motionScheme = path.Count > 3 ? _animDurations[AnimDurationTypes.RUNNING] : _animDurations[AnimDurationTypes.WALKING];

            float prevX = -1;
            float prevY = -1;

            for (int i = 0; i < path.Count; i++)
            {
                path[i].TryGetCoord(out float X, out float Y);
                
                if (i != 0)
                {
                    if (Y == prevY)
                    {
                        duration += motionScheme.Horizontal;
                    }
                    else if (X == prevY)
                    {
                        duration += motionScheme.Vertical;
                    }
                    else
                    {
                        duration += motionScheme.Linear;
                    }
                }
                
                prevX = X;
                prevY = Y;
            }

            return duration;
        }

    }

    internal class AnimDuration
    {

        // Properties
        public short Linear { get; private set; }
        public short Horizontal { get; private set; }
        public short Vertical { get; private set; }


        // Constructor
        public AnimDuration(short linear, short horizontal, short vertical)
        {
            Linear = linear;
            Horizontal = horizontal;
            Vertical = vertical;
        }

    }

    internal enum AnimDurationTypes
    {
        MOUNTED,
        PARABLE,
        RUNNING,
        WALKING,
        SLIDE
    }

}
