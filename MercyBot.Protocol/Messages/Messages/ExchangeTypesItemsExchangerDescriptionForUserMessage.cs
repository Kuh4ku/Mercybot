using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeTypesItemsExchangerDescriptionForUserMessage : Message
	{

		// Properties
		public List<BidExchangerObjectInfo> ItemTypeDescriptions { get; set; }


		// Constructors
		public ExchangeTypesItemsExchangerDescriptionForUserMessage() { }

		public ExchangeTypesItemsExchangerDescriptionForUserMessage(List<BidExchangerObjectInfo> itemTypeDescriptions = null)
		{
			ItemTypeDescriptions = itemTypeDescriptions;
		}

	}
}
