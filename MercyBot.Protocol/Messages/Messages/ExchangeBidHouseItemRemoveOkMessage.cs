using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeBidHouseItemRemoveOkMessage : Message
	{

		// Properties
		public int SellerId { get; set; }


		// Constructors
		public ExchangeBidHouseItemRemoveOkMessage() { }

		public ExchangeBidHouseItemRemoveOkMessage(int sellerId = 0)
		{
			SellerId = sellerId;
		}

	}
}
