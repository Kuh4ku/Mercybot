using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PaddockMoveItemRequestMessage : Message
	{

		// Properties
		public uint OldCellId { get; set; }
		public uint NewCellId { get; set; }


		// Constructors
		public PaddockMoveItemRequestMessage() { }

		public PaddockMoveItemRequestMessage(uint oldCellId = 0, uint newCellId = 0)
		{
			OldCellId = oldCellId;
			NewCellId = newCellId;
		}

	}
}
