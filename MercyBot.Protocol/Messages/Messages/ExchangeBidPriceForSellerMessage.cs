using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeBidPriceForSellerMessage : ExchangeBidPriceMessage
	{

		// Properties
		public List<uint> MinimalPrices { get; set; }
		public bool AllIdentical { get; set; }


		// Constructors
		public ExchangeBidPriceForSellerMessage() { }

		public ExchangeBidPriceForSellerMessage(uint genericId = 0, int averagePrice = 0, bool allIdentical = false, List<uint> minimalPrices = null)
		{
			GenericId = genericId;
			AveragePrice = averagePrice;
			AllIdentical = allIdentical;
			MinimalPrices = minimalPrices;
		}

	}
}
