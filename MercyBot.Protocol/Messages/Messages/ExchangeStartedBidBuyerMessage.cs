using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeStartedBidBuyerMessage : Message
	{

		// Properties
		public SellerBuyerDescriptor BuyerDescriptor { get; set; }


		// Constructors
		public ExchangeStartedBidBuyerMessage() { }

		public ExchangeStartedBidBuyerMessage(SellerBuyerDescriptor buyerDescriptor = null)
		{
			BuyerDescriptor = buyerDescriptor;
		}

	}
}
