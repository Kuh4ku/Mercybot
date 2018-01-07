using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MapViewer.Control
{
    public partial class MapViewer : UserControl
    {

        // Properties
        public MapViewerQualities Quality
        {
            get => _quality;
            set
            {
                _quality = value;
                Invalidate();
            }
        }
        public float Zoom
        {
            get => _zoom;
            set
            {
                if (value < 0) _zoom = 1f;
                else if (value > 2) _zoom = 2;
                else _zoom = value;

                InitializeMap();
                Size = new Size((int)Math.Ceiling(startingWidth * _zoom), (int)Math.Ceiling(startingHeight * _zoom));
            }
        }


        // Fields
        private const float TileWidth = 43;
        private const float TileHeight = 21.5f;
        private const int MAP_WIDTH = 14;
        private const int MAP_HEIGHT = 20;
        private const int startingWidth = 624;
        private const int startingHeight = 442;
        private MapViewerQualities _quality;
        private float _zoom = 1f;
        private MapCell[] _cells;


        // Constructor
        public MapViewer()
        {
            InitializeComponent();

            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);

            InitializeMap();
        }


        private void InitializeMap()
        {
            _cells = new MapCell[560];
            int cell = 0;

            for (int i = 0; i < MAP_HEIGHT; i++)
            {
                for (int j = 0; j < MAP_WIDTH; j++)
                {
                    SetCell(cell);
                    cell++;
                }
                for (int j = 0; j < MAP_WIDTH; j++)
                {
                    SetCell(cell);
                    cell++;
                }
            }
        }

        private void SetCell(int index)
        {
            Point p = GetCellCoords(index);
            float startPtX = p.X * (TileWidth * _zoom) + (p.Y % 2 == 1 ? (TileWidth * _zoom) / 2 : 0);
            float startPtY = p.Y * (TileHeight * _zoom) / 2;
            _cells[index] = new MapCell(new PointF(startPtX + (TileWidth * _zoom) / 2, startPtY),
                                         new PointF(startPtX + (TileWidth * _zoom), startPtY + (TileHeight * _zoom) / 2),
                                         new PointF(startPtX + (TileWidth * _zoom) / 2, startPtY + (TileHeight * _zoom)),
                                         new PointF(startPtX, startPtY + (TileHeight * _zoom) / 2));
        }

        private Point GetCellCoords(int cellId) => new Point(cellId % MAP_WIDTH, (int)Math.Floor((double)cellId / MAP_WIDTH));

        private void MapViewer_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SetQuality(g);
            
            foreach (MapCell cell in _cells)
            {
                // TODO: Put better colors
                if (cell.IsObstacle)
                {
                    cell.Draw(g, Color.Gray, Color.Black);
                }
                else if (cell.IsWalkable)
                {
                    cell.Draw(g, Color.Gray, Color.DarkGray);
                }
                else
                {
                    cell.Draw(g, Color.Gray, null);
                }
            }
        }

        private void SetQuality(Graphics g)
        {
            switch (_quality)
            {
                case MapViewerQualities.HIGH:
                    g.CompositingMode = CompositingMode.SourceOver;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    break;
                case MapViewerQualities.LOW:
                    g.CompositingMode = CompositingMode.SourceOver;
                    g.CompositingQuality = CompositingQuality.HighSpeed;
                    g.InterpolationMode = InterpolationMode.Low;
                    g.SmoothingMode = SmoothingMode.HighSpeed;
                    break;
            }
        }

    }
}
