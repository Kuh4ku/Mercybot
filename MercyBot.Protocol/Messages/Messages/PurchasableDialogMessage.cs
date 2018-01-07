using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PurchasableDialogMessage : Message
	{

		// Properties
		public bool BuyOrSell { get; set; }
		public uint PurchasableId { get; set; }
		public uint Price { get; set; }


		// Constructors
		public PurchasableDialogMessage() { }

		public PurchasableDialogMessage(bool buyOrSell = false, uint purchasableId = 0, uint price = 0)
		{
			BuyOrSell = buyOrSell;
			PurchasableId = purchasableId;
			Price = price;
		}

	}
}
