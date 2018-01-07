using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameActionMarkedCell
	{

		// Properties
		public uint CellId { get; set; }
		public int ZoneSize { get; set; }
		public int CellColor { get; set; }
		public int CellsType { get; set; }


		// Constructors
		public GameActionMarkedCell() { }

		public GameActionMarkedCell(uint cellId = 0, int zoneSize = 0, int cellColor = 0, int cellsType = 0)
		{
			CellId = cellId;
			ZoneSize = zoneSize;
			CellColor = cellColor;
			CellsType = cellsType;
		}

	}
}
