using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeRequestedMessage : Message
	{

		// Properties
		public int ExchangeType { get; set; }


		// Constructors
		public ExchangeRequestedMessage() { }

		public ExchangeRequestedMessage(int exchangeType = 0)
		{
			ExchangeType = exchangeType;
		}

	}
}
