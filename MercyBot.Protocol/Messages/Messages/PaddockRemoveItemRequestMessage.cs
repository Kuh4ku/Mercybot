using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PaddockRemoveItemRequestMessage : Message
	{

		// Properties
		public uint CellId { get; set; }


		// Constructors
		public PaddockRemoveItemRequestMessage() { }

		public PaddockRemoveItemRequestMessage(uint cellId = 0)
		{
			CellId = cellId;
		}

	}
}
