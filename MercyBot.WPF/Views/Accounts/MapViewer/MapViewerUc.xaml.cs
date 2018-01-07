using MercyBot.Core.Accounts;
using MercyBot.Core.Accounts.InGame.Managers.Movements;
using MercyBot.Core.Pathfinding;
using MercyBot.Utility.DofusTouch;
using MercyBot.Utility.Extensions;
using MercyBot.Views.Accounts.MapViewer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MercyBot.Views.Accounts
{
    public partial class MapViewerUc
    {

        // Fields
        private static List<MapViewerCell> _cellsPoints;
        private static Pen _pen;
        private static Brush _walkableCellBrush;
        private static Brush _losCellBrush;
        private static Brush _obstacleCellBrush;
        private static Brush _selectedCellBrush;
        private static Brush _ourPlayerBrush;
        private static Brush _monstersGroupsBrush;
        private static Brush _playersBrush;
        private static Brush _doorsBrush;
        private static Brush _interactivesBrush;
        private static Brush _npcsBrush;
        private static BitmapImage _sunImage;
        private static BitmapImage _phenixImage;
        private static BitmapImage _lockedStorageImage;
        private short _selectedCellId;
        private List<short> _path;
        private bool _showCellIds;


        // Properties
        public bool ShowCellIds
        {
            get => _showCellIds;
            set
            {
                _showCellIds = value;
                InvalidateVisual();
            }
        }
        private Account Account => MercyBotMain.Instance.SelectedAccount;
        private bool IsMapValid => Account?.Game?.Map?.Data != null;


        // Constructor
        public MapViewerUc()
        {
            InitializeComponent();
            Initialize();
            
            DataContextChanged += MapViewerUc_DataContextChanged;
            MouseLeftButtonUp += MapViewerUc_MouseLeftButtonUp;
        }


        private static void Initialize()
        {
            if (_cellsPoints != null)
                return;

            _pen = new Pen(Brushes.White, 1);
            _walkableCellBrush = new SolidColorBrush(Colors.DarkGray);
            _losCellBrush = new SolidColorBrush(Colors.Transparent);
            _obstacleCellBrush = new SolidColorBrush(Colors.Gray);
            _selectedCellBrush = new SolidColorBrush(Color.FromArgb(255, 91, 90, 90));
            _ourPlayerBrush = new SolidColorBrush(Colors.Blue);
            _monstersGroupsBrush = new SolidColorBrush(Color.FromArgb(255, 139, 0, 0));
            _playersBrush = new SolidColorBrush(Color.FromArgb(255, 81, 113, 202));
            _doorsBrush = new SolidColorBrush(Color.FromArgb(255, 150, 75, 13));
            _interactivesBrush = new SolidColorBrush(Color.FromArgb(255, 1, 143, 140));
            _npcsBrush = new SolidColorBrush(Color.FromArgb(255, 179, 120, 211));
            _sunImage = new BitmapImage(new Uri("pack://application:,,,/Resources/21000.png"));
            _phenixImage = new BitmapImage(new Uri("pack://application:,,,/Resources/7521.png"));
            _lockedStorageImage = new BitmapImage(new Uri("pack://application:,,,/Resources/12367.png"));

            // Freeze the used objects
            _pen.Freeze();
            _walkableCellBrush.Freeze();
            _losCellBrush.Freeze();
            _obstacleCellBrush.Freeze();
            _selectedCellBrush.Freeze();
            _ourPlayerBrush.Freeze();
            _monstersGroupsBrush.Freeze();
            _playersBrush.Freeze();
            _doorsBrush.Freeze();
            _interactivesBrush.Freeze();
            _npcsBrush.Freeze();
            _sunImage.Freeze();
            _phenixImage.Freeze();
            _lockedStorageImage.Freeze();

            _cellsPoints = new List<MapViewerCell>(560);
            short cell = 0;

            for (int i = 0; i < DTConstants.MAP_HEIGHT; i++)
            {
                for (int j = 0; j < DTConstants.MAP_WIDTH * 2; j++)
                {
                    if (cell.TryGetCoord(out float x, out float y))
                    {
                        float startPtX = x * (DTConstants.TileWidth) + (y % 2 == 1 ? (DTConstants.TileWidth) / 2 : 0);
                        float startPtY = y * (DTConstants.TileHeight) / 2;
                        _cellsPoints.Add(new MapViewerCell(new[]
                        {
                            new Point(startPtX + (DTConstants.TileWidth) / 2, startPtY),
                            new Point(startPtX + (DTConstants.TileWidth), startPtY + (DTConstants.TileHeight) / 2),
                            new Point(startPtX + (DTConstants.TileWidth) / 2, startPtY + (DTConstants.TileHeight)),
                            new Point(startPtX, startPtY + (DTConstants.TileHeight) / 2)
                        }));
                    }
                    cell++;
                }
            }
        }

        #region Invalidation

        private void MapViewerUc_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var oldAccount = e.OldValue as Account;
            var newAccount = e.NewValue as Account;

            if (oldAccount != null)
            {
                oldAccount.Game.Map.MapChanged -= RefreshMapViewer;
                oldAccount.Game.Map.EntitiesUpdated -= RefreshMapViewer;
                oldAccount.Game.Map.InteractivesUpdated -= RefreshMapViewer;
                oldAccount.Game.Map.PlayedCharacterMoving -= PlayedCharacterMoving;
                oldAccount.Game.Fight.FightJoined -= RefreshMapViewer;
                oldAccount.Game.Fight.PossiblePositionsReceived -= RefreshMapViewer;
                oldAccount.Game.Fight.FightStarted -= RefreshMapViewer;
                oldAccount.Game.Fight.FightersUpdated -= RefreshMapViewer;
                oldAccount.Game.Fight.PlayedFighterMoving -= PlayedCharacterMoving;
            }

            _selectedCellId = -1;
            _path = null;

            if (newAccount != null)
            {
                newAccount.Game.Map.MapChanged += RefreshMapViewer;
                newAccount.Game.Map.EntitiesUpdated += RefreshMapViewer;
                newAccount.Game.Map.InteractivesUpdated += RefreshMapViewer;
                newAccount.Game.Map.PlayedCharacterMoving += PlayedCharacterMoving;
                newAccount.Game.Fight.FightJoined += RefreshMapViewer;
                newAccount.Game.Fight.PossiblePositionsReceived += RefreshMapViewer;
                newAccount.Game.Fight.FightStarted += RefreshMapViewer;
                newAccount.Game.Fight.FightersUpdated += RefreshMapViewer;
                newAccount.Game.Fight.PlayedFighterMoving += PlayedCharacterMoving;
                InvalidateVisual();
            }
        }

        private void RefreshMapViewer()
        {
            Application.Current?.Dispatcher.Invoke(() => InvalidateVisual());
        }

        private void PlayedCharacterMoving(List<short> path)
        {
            _path = path;
            Application.Current.Dispatcher.Invoke(() => InvalidateVisual());

            Task.Run(async () =>
            {
                await Task.Delay(PathDuration.Calculate(path));

                if (_path != null)
                {
                    _path = null;
                    Application.Current.Dispatcher.Invoke(() => InvalidateVisual());
                }
            });
        }

        #endregion

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            for (short i = 0; i < _cellsPoints.Count; i++)
            {
                var brush = GetCellBrush(i);

                if (brush == _obstacleCellBrush && !ShowCellIds)
                {
                    _cellsPoints[i].DrawObstacle(drawingContext, brush, _pen);
                }
                else
                {
                    _cellsPoints[i].Draw(drawingContext, brush, _pen);

                    

                    if (_path?.Contains(i) == true)
                    {
                        _cellsPoints[i].DrawCross(drawingContext, _pen);
                    }
                }

                if (ShowCellIds)
                {
                    var fText = new FormattedText(i.ToString(), CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Segoe UI"), 10, brush == _losCellBrush ? Brushes.White : Brushes.Black);
                    drawingContext.DrawText(fText, new Point(_cellsPoints[i].Points[0].X - fText.Width / 2, _cellsPoints[i].Points[1].Y - fText.Height / 2));
                }

                if (IsMapValid)
                {
                    // Draw the sun image if this cell has it
                    if (Account.Game.Map.TeleportableCells.Contains(i))
                    {
                        _cellsPoints[i].DrawImage(drawingContext, _sunImage);   
                    }
                    else if (Account.Game.Map.Phenixs.FirstOrDefault(p => p.CellId == i) != null)
                    {
                        _cellsPoints[i].DrawImage(drawingContext, _phenixImage);
                    }
                    else if (Account.Game.Map.LockedStroages.FirstOrDefault(ls => ls.CellId == i) != null)
                    {
                        _cellsPoints[i].DrawImage(drawingContext, _lockedStorageImage);
                    }

                    DrawTileContent(drawingContext, i);
                }
            }
        }

        private Brush GetCellBrush(short cell)
        {
            // In case the cell is currently selected
            if (cell == _selectedCellId)
                return _selectedCellBrush;

            // In case the cell is a possible placement
            if (IsMapValid && Account.IsFighting() && Account.Game.Fight.PositionsForChallengers?.Contains(cell) == true)
                return Brushes.Red;

            if (IsMapValid && Account.IsFighting() && Account.Game.Fight.PositionsForDefenders?.Contains(cell) == true)
                return Brushes.Blue;

            var brush = _losCellBrush;

            if (IsMapValid && Account.Game.Map.Data.Cells[cell].IsObstacle())
                brush = _obstacleCellBrush;
            else if (IsMapValid && Account.Game.Map.Data.Cells[cell].IsWalkable(Account.IsFighting()))
                brush = _walkableCellBrush;

            return brush;
        }

        private void DrawTileContent(DrawingContext drawingContext, short cellId)
        {
            if (Account.IsFighting())
            {
                if (Account.Game.Fight.PlayedFighter?.CellId == cellId)
                {
                    _cellsPoints[cellId].DrawPie(drawingContext, _ourPlayerBrush);
                }
                else if (Account.Game.Fight.Allies.FirstOrDefault(a => a.CellId == cellId) != null)
                {
                    _cellsPoints[cellId].DrawPie(drawingContext, _playersBrush);
                }
                else if (Account.Game.Fight.Ennemies.FirstOrDefault(e => e.CellId == cellId) != null)
                {
                    _cellsPoints[cellId].DrawPie(drawingContext, _monstersGroupsBrush);
                }
            }
            else
            {
                if (Account.Game.Map.PlayedCharacter?.CellId == cellId)
                {
                    _cellsPoints[cellId].DrawPie(drawingContext, _ourPlayerBrush);
                }
                else if (Account.Game.Map.MonstersGroups.FirstOrDefault(mg => mg.CellId == cellId) != null)
                {
                    _cellsPoints[cellId].DrawPie(drawingContext, _monstersGroupsBrush);
                }
                else if (Account.Game.Map.Players.FirstOrDefault(p => p.CellId == cellId) != null)
                {
                    _cellsPoints[cellId].DrawPie(drawingContext, _playersBrush);
                }
                else if (Account.Game.Map.Doors.FirstOrDefault(d => d.CellId == cellId) != null)
                {
                    _cellsPoints[cellId].DrawRectangle(drawingContext, _doorsBrush);
                }
                else if (Account.Game.Map.StatedElements.FirstOrDefault(se => se.CellId == cellId) != null || 
                    Account.Game.Map.Zaap?.CellId == cellId || Account.Game.Map.Zaapi?.CellId == cellId)
                {
                    _cellsPoints[cellId].DrawRectangle(drawingContext, _interactivesBrush);
                }
                else if (Account.Game.Map.Npcs.FirstOrDefault(n => n.CellId == cellId) != null)
                {
                    _cellsPoints[cellId].DrawPie(drawingContext, _npcsBrush);
                }
            }
        }

        private void MapViewerUc_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // No need to check if the map is not valid or the bot is not inactif
            if (!IsMapValid || Account.IsBusy)
                return;

            var pos = e.GetPosition(this);

            for (short i = 0; i < _cellsPoints.Count; i++)
            {
                if (_cellsPoints[i].IsPointInside(pos))
                {
                    if (Account.Game.Map.Data.Cells[i].IsWalkable(false))
                    {
                        _selectedCellId = i;
                        InvalidateVisual();

                        Task.Run(async () =>
                        {
                            await Task.Delay(200);

                            if (_selectedCellId != -1)
                            {
                                _selectedCellId = -1;
                                Application.Current.Dispatcher.Invoke(InvalidateVisual);
                            }
                        });

                        HandleWalkableCellClicked(i);
                    }

                    break;
                }
            }
        }

        private void HandleWalkableCellClicked(short cell)
        {
            // Check if we can change the map from this cell
            if (Account.Game.Managers.Movements.CanChangeMap(cell, MapChangeDirections.LEFT))
                Account.Game.Managers.Movements.ChangeMap(MapChangeDirections.LEFT, cell);
            else if (Account.Game.Managers.Movements.CanChangeMap(cell, MapChangeDirections.RIGHT))
                Account.Game.Managers.Movements.ChangeMap(MapChangeDirections.RIGHT, cell);
            else if (Account.Game.Managers.Movements.CanChangeMap(cell, MapChangeDirections.TOP))
                Account.Game.Managers.Movements.ChangeMap(MapChangeDirections.TOP, cell);
            else if (Account.Game.Managers.Movements.CanChangeMap(cell, MapChangeDirections.BOTTOM))
                Account.Game.Managers.Movements.ChangeMap(MapChangeDirections.BOTTOM, cell);
            // Otherwise just move to the cell
            else
            {
                Console.WriteLine(Account.Game.Managers.Movements.MoveToCell(cell));
            }
        }

    }
}
