using MercyBot.Protocol.Data.Maps;
using System;
using System.Collections.Generic;

namespace MercyBot.Core.Pathfinding
{
    public static class Dofus1Line
    {

        public static bool IsLineObstructed(Map map, short sourceCellId, short targetCellId, List<short> occupiedCells, bool diagonal = false)
        {
            MapPoint sourceMp = MapPoint.FromCellId(sourceCellId);
            MapPoint targetMp = MapPoint.FromCellId(targetCellId);

            double x = sourceMp.X + 0.5;
            double y = sourceMp.Y + 0.5;
            double targetX = targetMp.X + 0.5;
            double targetY = targetMp.Y + 0.5;
            double lastX = sourceMp.X;
            double lastY = sourceMp.Y;

            double padX = 0;
            double padY = 0;
            double steps = 0;
            int cas = 0;

            if (Math.Abs(x - targetX) == Math.Abs(y - targetY))
            {
                steps = Math.Abs(x - targetX);
                padX = (targetX > x) ? 1 : -1;
                padY = (targetY > y) ? 1 : -1;
                cas = 1;
            }
            else if (Math.Abs(x - targetX) > Math.Abs(y - targetY))
            {
                steps = Math.Abs(x - targetX);
                padX = (targetX > x) ? 1 : -1;
                padY = (targetY - y) / steps;
                padY = padY * 100;
                padY = Math.Ceiling(padY) / 100;
                cas = 2;
            }
            else
            {
                steps = Math.Abs(y - targetY);
                padX = (targetX - x) / steps;
                padX = padX * 100;
                padX = Math.Ceiling(padX) / 100;
                padY = (targetY > y) ? 1 : -1;
                cas = 3;
            }

            int errorSup = Convert.ToInt32(Math.Round(Math.Floor(Convert.ToDouble((3 + (steps / 2))))));
            int errorInf = Convert.ToInt32(Math.Round(Math.Floor(Convert.ToDouble((97 - (steps / 2))))));

            for (int i = 0; i < steps; i++)
            {
                double cellX, cellY;
                double xPadX = x + padX;
                double yPadY = y + padY;

                switch (cas)
                {
                    case 2:
                        double beforeY = Math.Ceiling(y * 100 + padY * 50) / 100;
                        double afterY = Math.Floor(y * 100 + padY * 150) / 100;
                        double diffBeforeCenterY = Math.Floor(Math.Abs(Math.Floor(beforeY) * 100 - beforeY * 100)) / 100;
                        double diffCenterAfterY = Math.Ceiling(Math.Abs(Math.Ceiling(afterY) * 100 - afterY * 100)) / 100;

                        cellX = Math.Floor(xPadX);

                        if (Math.Floor(beforeY) == Math.Floor(afterY))
                        {
                            cellY = Math.Floor(yPadY);
                            if ((beforeY == cellY && afterY < cellY) || (afterY == cellY && beforeY < cellY))
                            {
                                cellY = Math.Ceiling(yPadY);
                            }
                            if (IsCellObstructed(cellX, cellY, map, occupiedCells, targetCellId, lastX, lastY, diagonal)) return true;
                            lastX = cellX;
                            lastY = cellY;
                        }
                        else if (Math.Ceiling(beforeY) == Math.Ceiling(afterY))
                        {
                            cellY = Math.Ceiling(yPadY);
                            if ((beforeY == cellY && afterY < cellY) || (afterY == cellY && beforeY < cellY))
                            {
                                cellY = Math.Floor(yPadY);
                            }
                            if (IsCellObstructed(cellX, cellY, map, occupiedCells, targetCellId, lastX, lastY, diagonal)) return true;
                            lastX = cellX;
                            lastY = cellY;
                        }
                        else if (Math.Floor(diffBeforeCenterY * 100) <= errorSup)
                        {
                            if (IsCellObstructed(cellX, Math.Floor(afterY), map, occupiedCells, targetCellId, lastX, lastY, diagonal)) return true;
                            lastX = cellX;
                            lastY = Math.Floor(afterY);
                        }
                        else if (Math.Floor(diffCenterAfterY * 100) >= errorInf)
                        {
                            if (IsCellObstructed(cellX, Math.Floor(beforeY), map, occupiedCells, targetCellId, lastX, lastY, diagonal)) return true;
                            lastX = cellX;
                            lastY = Math.Floor(beforeY);
                        }
                        else
                        {
                            if (IsCellObstructed(cellX, Math.Floor(beforeY), map, occupiedCells, targetCellId, lastX, lastY, diagonal)) return true;
                            lastX = cellX;
                            lastY = Math.Floor(beforeY);
                            if (IsCellObstructed(cellX, Math.Floor(afterY), map, occupiedCells, targetCellId, lastX, lastY, diagonal)) return true;
                            lastY = Math.Floor(afterY);
                        }
                        break;
                    case 3:
                        double beforeX = Math.Ceiling(x * 100 + padX * 50) / 100;
                        double afterX = Math.Floor(x * 100 + padX * 150) / 100;
                        double diffBeforeCenterX = Math.Floor(Math.Abs(Math.Floor(beforeX) * 100 - beforeX * 100)) / 100;
                        double diffCenterAfterX = Math.Ceiling(Math.Abs(Math.Ceiling(afterX) * 100 - afterX * 100)) / 100;

                        cellY = Math.Floor(yPadY);

                        if (Math.Floor(beforeX) == Math.Floor(afterX))
                        {
                            cellX = Math.Floor(xPadX);
                            if ((beforeX == cellX && afterX < cellX) || (afterX == cellX && beforeX < cellX))
                            {
                                cellX = Math.Ceiling(xPadX);
                            }
                            if (IsCellObstructed(cellX, cellY, map, occupiedCells, targetCellId, lastX, lastY, diagonal)) return true;
                            lastX = cellX;
                            lastY = cellY;
                        }
                        else if (Math.Ceiling(beforeX) == Math.Ceiling(afterX))
                        {
                            cellX = Math.Ceiling(xPadX);
                            if ((beforeX == cellX && afterX < cellX) || (afterX == cellX && beforeX < cellX))
                            {
                                cellX = Math.Floor(xPadX);
                            }
                            if (IsCellObstructed(cellX, cellY, map, occupiedCells, targetCellId, lastX, lastY, diagonal)) return true;
                            lastX = cellX;
                            lastY = cellY;
                        }
                        else if (Math.Floor(diffBeforeCenterX * 100) <= errorSup)
                        {
                            if (IsCellObstructed(Math.Floor(afterX), cellY, map, occupiedCells, targetCellId, lastX, lastY, diagonal)) return true;
                            lastX = Math.Floor(afterX);
                            lastY = cellY;
                        }
                        else if (Math.Floor(diffCenterAfterX * 100) >= errorInf)
                        {
                            if (IsCellObstructed(Math.Floor(beforeX), cellY, map, occupiedCells, targetCellId, lastX, lastY, diagonal)) return true;
                            lastX = Math.Floor(beforeX);
                            lastY = cellY;
                        }
                        else
                        {
                            if (IsCellObstructed(Math.Floor(beforeX), cellY, map, occupiedCells, targetCellId, lastX, lastY, diagonal)) return true;
                            lastX = Math.Floor(beforeX);
                            lastY = cellY;
                            if (IsCellObstructed(Math.Floor(afterX), cellY, map, occupiedCells, targetCellId, lastX, lastY, diagonal)) return true;
                            lastX = Math.Floor(afterX);
                        }
                        break;
                    default: // cas == 1
                        if (IsCellObstructed(Math.Floor(xPadX), Math.Floor(yPadY), map, occupiedCells, targetCellId, lastX, lastY, diagonal)) return true;
                        lastX = Math.Floor(xPadX);
                        lastY = Math.Floor(yPadY);
                        break;
                }

                x = (x * 100 + padX * 100) / 100;
                y = (y * 100 + padY * 100) / 100;
            }

            return false;
        }

        private static bool IsCellObstructed(double x, double y, Map map, List<short> occupiedCells, short targetCellId, double lastX, double lastY, bool diagonal)
        {
            MapPoint mp = MapPoint.FromCoords((int)x, (int)y);

            if (((map.Cells[mp.CellId].IsObstacle()) || (mp.CellId != targetCellId && occupiedCells.Contains(mp.CellId))))
                return true;

            // Diagonal
            if (diagonal)
            {
                MapPoint lmp = MapPoint.FromCoords((int)lastX, (int)lastY);

                return (!((mp.X == lmp.X + 1 && mp.Y == lmp.Y + 1) ||
                          (mp.X == lmp.X + 1 && mp.Y == lmp.Y - 1) ||
                          (mp.X == lmp.X - 1 && mp.Y == lmp.Y + 1) ||
                          (mp.X == lmp.X - 1 && mp.Y == lmp.Y - 1)));
            }
            else
                return false;
        }

    }
}
