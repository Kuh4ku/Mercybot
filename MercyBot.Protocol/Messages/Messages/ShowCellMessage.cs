using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ShowCellMessage : Message
	{

		// Properties
		public int SourceId { get; set; }
		public uint CellId { get; set; }


		// Constructors
		public ShowCellMessage() { }

		public ShowCellMessage(int sourceId = 0, uint cellId = 0)
		{
			SourceId = sourceId;
			CellId = cellId;
		}

	}
}
