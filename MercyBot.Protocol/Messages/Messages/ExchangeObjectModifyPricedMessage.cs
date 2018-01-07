using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeObjectModifyPricedMessage : ExchangeObjectMovePricedMessage
	{

		// Constructors
		public ExchangeObjectModifyPricedMessage() { }

		public ExchangeObjectModifyPricedMessage(uint objectUID = 0, int quantity = 0, int price = 0)
		{
			ObjectUID = objectUID;
			Quantity = quantity;
			Price = price;
		}

	}
}
