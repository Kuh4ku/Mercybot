using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeSellMessage : Message
	{

		// Properties
		public uint ObjectToSellId { get; set; }
		public uint Quantity { get; set; }


		// Constructors
		public ExchangeSellMessage() { }

		public ExchangeSellMessage(uint objectToSellId = 0, uint quantity = 0)
		{
			ObjectToSellId = objectToSellId;
			Quantity = quantity;
		}

	}
}
