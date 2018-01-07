using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeShopStockStartedMessage : Message
	{

		// Properties
		public List<ObjectItemToSell> ObjectsInfos { get; set; }


		// Constructors
		public ExchangeShopStockStartedMessage() { }

		public ExchangeShopStockStartedMessage(List<ObjectItemToSell> objectsInfos = null)
		{
			ObjectsInfos = objectsInfos;
		}

	}
}
