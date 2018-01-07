using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeRequestedTradeMessage : ExchangeRequestedMessage
	{

		// Properties
		public uint Source { get; set; }
		public uint Target { get; set; }


		// Constructors
		public ExchangeRequestedTradeMessage() { }

		public ExchangeRequestedTradeMessage(int exchangeType = 0, uint source = 0, uint target = 0)
		{
			ExchangeType = exchangeType;
			Source = source;
			Target = target;
		}

	}
}
