using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ShowCellRequestMessage : Message
	{

		// Properties
		public uint CellId { get; set; }


		// Constructors
		public ShowCellRequestMessage() { }

		public ShowCellRequestMessage(uint cellId = 0)
		{
			CellId = cellId;
		}

	}
}
