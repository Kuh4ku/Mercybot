namespace MercyBot.Core.Pathfinding.Shapes.Zones
{
    public static class ZonesUtility
    {
        /*
         * var EFFECT_SHAPES = {
		// cross - getText('ui.spellarea.cross')
		X: { code: 88,   desc: 'ui.spellarea.cross',      alt: '',      hasMinSize: true },
		// inline - getText('ui.spellarea.line')
		L: { code: 76,   desc: 'ui.spellarea.line',       alt: '',      hasMinSize: false },
		// perpendicular line - getText('ui.spellarea.tarea')
		T: { code: 84,   desc: 'ui.spellarea.tarea',      alt: '',      hasMinSize: false },
		// point (circle size 0)
		P: { code: 80,   desc: '',                        alt: '',      hasMinSize: false },
		// circle with chessboard pattern - getText('ui.spellarea.chessboard')
		D: { code: 68,   desc: 'ui.spellarea.chessboard', alt: '',      hasMinSize: false },
		// circle - getText('ui.spellarea.circle')
		C: { code: 67,   desc: 'ui.spellarea.circle',     alt: '',      hasMinSize: true },
		// ring (circle perimeter) - getText('ui.spellarea.ring')
		O: { code: 79,   desc: 'ui.spellarea.ring',       alt: '',      hasMinSize: false },
		// cross without central point - getText('ui.spellarea.crossVoid')
		Q: { code: 81,   desc: 'ui.spellarea.crossVoid',  alt: '',      hasMinSize: true },
		// directional cone - getText('ui.spellarea.cone')
		V: { code: 86,   desc: 'ui.spellarea.cone',       alt: '',      hasMinSize: false },
		// 4 cones without diagonals
		W: { code: 87,   desc: '',                        alt: '',      hasMinSize: false },
		// 4 diagonals
		'+': { code: 43, desc: '',                        alt: 'plus',  hasMinSize: true },
		// diagonals without the central point
		'#': { code: 35, desc: '',                        alt: 'sharp', hasMinSize: true },
		// lines and diagonals
		'*': { code: 42, desc: '',                        alt: 'star',  hasMinSize: false },
		// aligned diagonals
		'/': { code: 47, desc: '',                        alt: 'slash', hasMinSize: false },
		// perpendicular diagonal - getText('ui.spellarea.diagonal')
		'-': { code: 45, desc: 'ui.spellarea.diagonal',   alt: 'minus', hasMinSize: false },
		// diamond - getText('ui.spellarea.square')
		G: { code: 71,   desc: 'ui.spellarea.square',     alt: '',      hasMinSize: false },
		// inverted circle (infinite if min range > 0)
		I: { code: 73,   desc: '',                        alt: '',      hasMinSize: false },
		// halfcircle - getText('ui.spellarea.halfcircle')
		U: { code: 85,   desc: 'ui.spellarea.halfcircle', alt: '',      hasMinSize: false },
		// whole map, all players - getText('ui.spellarea.everyone')
		A: { code: 65,   desc: 'ui.spellarea.everyone',   alt: '',      hasMinSize: false }
	};*/

        public static bool HasMinSize(char shape)
        {
            switch (shape)
            {
                case 'X':
                case 'C':
                case 'Q':
                case '+':
                case '#':
                    return true;
                case 'L':
                case 'T':
                case 'P':
                case 'D':
                case 'O':
                case 'V':
                case 'W':
                case '*':
                case '/':
                case '-':
                case 'G':
                case 'I':
                case 'U':
                case 'A':
                default:
                    return false;
            }
        }

        public static Zone ParseZone(string rawZone)
        {
            char zoneShape = rawZone[0];
            var @params = rawZone.Length > 1 ? rawZone.Substring(1).Split(',') : new string[0];
            int zoneSize = 0, zoneMinSize = 0, zoneEfficiencyPercent = 0, zoneMaxEfficiency = 0;

            switch (@params.Length)
            {
                case 1:
                    zoneSize = int.Parse(@params[0]);
                    break;
                case 2:
                    zoneSize = int.Parse(@params[0]);
                    if (HasMinSize(zoneShape))
                    {
                        zoneMinSize = int.Parse(@params[1]);
                    }
                    else
                    {
                        zoneEfficiencyPercent = int.Parse(@params[1]);
                    }
                    break;
                case 3:
                    zoneSize = int.Parse(@params[0]);
                    if (HasMinSize(zoneShape))
                    {
                        zoneMinSize = int.Parse(@params[1]);
                        zoneEfficiencyPercent = int.Parse(@params[2]);
                    }
                    else
                    {
                        zoneEfficiencyPercent = int.Parse(@params[1]);
                        zoneMaxEfficiency = int.Parse(@params[2]);
                    }
                    break;
                case 4:
                    zoneSize = int.Parse(@params[0]);
                    zoneMinSize = int.Parse(@params[1]);
                    zoneEfficiencyPercent = int.Parse(@params[2]);
                    zoneMaxEfficiency = int.Parse(@params[3]);
                    break;
            }

            return new Zone()
            {
                ZoneShape = zoneShape,
                ZoneSize = zoneSize,
                ZoneMinSize = zoneMinSize,
                ZoneEfficiencyPercent = zoneEfficiencyPercent,
                ZoneMaxEfficiency = zoneMaxEfficiency
            };
        }

    }

    public class Zone
    {

        // Properties
        public char ZoneShape { get; internal set; }
        public int ZoneSize { get; internal set; }
        public int ZoneMinSize { get; internal set; }
        public int ZoneEfficiencyPercent { get; internal set; }
        public int ZoneMaxEfficiency { get; internal set; }


        // Constructor
        internal Zone() { }

    }

}
