using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeShopStockMovementRemovedMessage : Message
	{

		// Properties
		public uint ObjectId { get; set; }


		// Constructors
		public ExchangeShopStockMovementRemovedMessage() { }

		public ExchangeShopStockMovementRemovedMessage(uint objectId = 0)
		{
			ObjectId = objectId;
		}

	}
}
