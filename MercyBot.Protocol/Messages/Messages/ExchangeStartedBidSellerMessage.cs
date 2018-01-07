using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeStartedBidSellerMessage : Message
	{

		// Properties
		public List<ObjectItemToSellInBid> ObjectsInfos { get; set; }
		public SellerBuyerDescriptor SellerDescriptor { get; set; }


		// Constructors
		public ExchangeStartedBidSellerMessage() { }

		public ExchangeStartedBidSellerMessage(SellerBuyerDescriptor sellerDescriptor = null, List<ObjectItemToSellInBid> objectsInfos = null)
		{
			SellerDescriptor = sellerDescriptor;
			ObjectsInfos = objectsInfos;
		}

	}
}
