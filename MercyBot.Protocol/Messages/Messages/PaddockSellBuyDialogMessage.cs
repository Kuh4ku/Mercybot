using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PaddockSellBuyDialogMessage : Message
	{

		// Properties
		public bool Bsell { get; set; }
		public uint OwnerId { get; set; }
		public uint Price { get; set; }


		// Constructors
		public PaddockSellBuyDialogMessage() { }

		public PaddockSellBuyDialogMessage(bool bsell = false, uint ownerId = 0, uint price = 0)
		{
			Bsell = bsell;
			OwnerId = ownerId;
			Price = price;
		}

	}
}
