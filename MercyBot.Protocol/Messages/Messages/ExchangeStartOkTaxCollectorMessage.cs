using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeStartOkTaxCollectorMessage : Message
	{

		// Properties
		public List<ObjectItem> ObjectsInfos { get; set; }
		public int CollectorId { get; set; }
		public uint GoldInfo { get; set; }


		// Constructors
		public ExchangeStartOkTaxCollectorMessage() { }

		public ExchangeStartOkTaxCollectorMessage(int collectorId = 0, uint goldInfo = 0, List<ObjectItem> objectsInfos = null)
		{
			CollectorId = collectorId;
			GoldInfo = goldInfo;
			ObjectsInfos = objectsInfos;
		}

	}
}
