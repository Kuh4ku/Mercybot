using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeReplayCountModifiedMessage : Message
	{

		// Properties
		public int Count { get; set; }


		// Constructors
		public ExchangeReplayCountModifiedMessage() { }

		public ExchangeReplayCountModifiedMessage(int count = 0)
		{
			Count = count;
		}

	}
}
