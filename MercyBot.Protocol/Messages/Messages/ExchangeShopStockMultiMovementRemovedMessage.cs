using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeShopStockMultiMovementRemovedMessage : Message
	{

		// Properties
		public List<uint> ObjectIdList { get; set; }


		// Constructors
		public ExchangeShopStockMultiMovementRemovedMessage() { }

		public ExchangeShopStockMultiMovementRemovedMessage(List<uint> objectIdList = null)
		{
			ObjectIdList = objectIdList;
		}

	}
}
