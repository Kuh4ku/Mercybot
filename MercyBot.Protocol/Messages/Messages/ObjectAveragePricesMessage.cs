using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectAveragePricesMessage : Message
	{

		// Properties
		public List<uint> Ids { get; set; }
		public List<uint> AvgPrices { get; set; }


		// Constructors
		public ObjectAveragePricesMessage() { }

		public ObjectAveragePricesMessage(List<uint> ids = null, List<uint> avgPrices = null)
		{
			Ids = ids;
			AvgPrices = avgPrices;
		}

	}
}
