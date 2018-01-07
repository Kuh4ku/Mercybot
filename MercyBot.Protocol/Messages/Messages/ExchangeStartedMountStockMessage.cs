using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeStartedMountStockMessage : Message
	{

		// Properties
		public List<ObjectItem> ObjectsInfos { get; set; }


		// Constructors
		public ExchangeStartedMountStockMessage() { }

		public ExchangeStartedMountStockMessage(List<ObjectItem> objectsInfos = null)
		{
			ObjectsInfos = objectsInfos;
		}

	}
}
