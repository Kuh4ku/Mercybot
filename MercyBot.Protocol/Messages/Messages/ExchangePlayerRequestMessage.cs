using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangePlayerRequestMessage : ExchangeRequestMessage
	{

		// Properties
		public uint Target { get; set; }


		// Constructors
		public ExchangePlayerRequestMessage() { }

		public ExchangePlayerRequestMessage(int exchangeType = 0, uint target = 0)
		{
			ExchangeType = exchangeType;
			Target = target;
		}

	}
}
