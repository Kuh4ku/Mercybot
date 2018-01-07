using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeShopStockMovementUpdatedMessage : Message
	{

		// Properties
		public ObjectItemToSell ObjectInfo { get; set; }


		// Constructors
		public ExchangeShopStockMovementUpdatedMessage() { }

		public ExchangeShopStockMovementUpdatedMessage(ObjectItemToSell objectInfo = null)
		{
			ObjectInfo = objectInfo;
		}

	}
}
