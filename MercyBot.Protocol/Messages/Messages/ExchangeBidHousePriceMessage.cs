using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeBidHousePriceMessage : Message
	{

		// Properties
		public uint GenId { get; set; }


		// Constructors
		public ExchangeBidHousePriceMessage() { }

		public ExchangeBidHousePriceMessage(uint genId = 0)
		{
			GenId = genId;
		}

	}
}
