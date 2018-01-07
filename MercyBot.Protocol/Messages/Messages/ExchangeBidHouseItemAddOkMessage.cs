using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeBidHouseItemAddOkMessage : Message
	{

		// Properties
		public ObjectItemToSellInBid ItemInfo { get; set; }


		// Constructors
		public ExchangeBidHouseItemAddOkMessage() { }

		public ExchangeBidHouseItemAddOkMessage(ObjectItemToSellInBid itemInfo = null)
		{
			ItemInfo = itemInfo;
		}

	}
}
