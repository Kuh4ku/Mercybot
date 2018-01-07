using System.Drawing;
using System.Drawing.Drawing2D;

namespace MapViewer.Control
{
    public class MapCell
    {

        // Properties
        public PointF[] Points { get; private set; }
        public bool IsObstacle { get; private set; }
        public bool IsWalkable { get; private set; }


        // Constructor
        public MapCell(PointF p1, PointF p2, PointF p3, PointF p4)
        {
            Points = new PointF[5] { p1, p2, p3, p4, p1 };
            IsObstacle = false;
            IsWalkable = false;
        }


        public void Draw(Graphics g, Color borderColor, Color? fillingColor)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddLines(Points);

                if (fillingColor != null)
                {
                    using (SolidBrush brush = new SolidBrush(fillingColor.Value))
                    {
                        g.FillPath(brush, path);
                    }
                }

                using (Pen pen = new Pen(borderColor))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

    }
}
