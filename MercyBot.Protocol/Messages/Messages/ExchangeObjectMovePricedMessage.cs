using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeObjectMovePricedMessage : ExchangeObjectMoveMessage
	{

		// Properties
		public int Price { get; set; }


		// Constructors
		public ExchangeObjectMovePricedMessage() { }

		public ExchangeObjectMovePricedMessage(uint objectUID = 0, int quantity = 0, int price = 0)
		{
			ObjectUID = objectUID;
			Quantity = quantity;
			Price = price;
		}

	}
}
