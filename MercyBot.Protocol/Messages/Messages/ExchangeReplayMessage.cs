using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeReplayMessage : Message
	{

		// Properties
		public int Count { get; set; }


		// Constructors
		public ExchangeReplayMessage() { }

		public ExchangeReplayMessage(int count = 0)
		{
			Count = count;
		}

	}
}
