using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapViewer
{
    public class MidroundLayerEntry
    {
        public float g { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float cw { get; set; }
        public float ch { get; set; }
        public List<sbyte> Hue { get; set; }

    }
}
