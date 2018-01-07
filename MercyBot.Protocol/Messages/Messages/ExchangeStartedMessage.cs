using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeStartedMessage : Message
	{

		// Properties
		public int ExchangeType { get; set; }


		// Constructors
		public ExchangeStartedMessage() { }

		public ExchangeStartedMessage(int exchangeType = 0)
		{
			ExchangeType = exchangeType;
		}

	}
}
