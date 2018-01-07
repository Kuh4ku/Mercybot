using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeBidHouseInListRemovedMessage : Message
	{

		// Properties
		public int ItemUID { get; set; }


		// Constructors
		public ExchangeBidHouseInListRemovedMessage() { }

		public ExchangeBidHouseInListRemovedMessage(int itemUID = 0)
		{
			ItemUID = itemUID;
		}

	}
}
