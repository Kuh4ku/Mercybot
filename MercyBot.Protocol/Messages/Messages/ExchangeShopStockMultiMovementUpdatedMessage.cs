using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeShopStockMultiMovementUpdatedMessage : Message
	{

		// Properties
		public List<ObjectItemToSell> ObjectInfoList { get; set; }


		// Constructors
		public ExchangeShopStockMultiMovementUpdatedMessage() { }

		public ExchangeShopStockMultiMovementUpdatedMessage(List<ObjectItemToSell> objectInfoList = null)
		{
			ObjectInfoList = objectInfoList;
		}

	}
}
