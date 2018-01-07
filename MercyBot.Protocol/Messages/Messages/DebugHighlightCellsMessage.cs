using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class DebugHighlightCellsMessage : Message
	{

		// Properties
		public List<uint> Cells { get; set; }
		public int Color { get; set; }


		// Constructors
		public DebugHighlightCellsMessage() { }

		public DebugHighlightCellsMessage(int color = 0, List<uint> cells = null)
		{
			Color = color;
			Cells = cells;
		}

	}
}
