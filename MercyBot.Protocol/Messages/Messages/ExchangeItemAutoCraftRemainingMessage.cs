using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeItemAutoCraftRemainingMessage : Message
	{

		// Properties
		public uint Count { get; set; }


		// Constructors
		public ExchangeItemAutoCraftRemainingMessage() { }

		public ExchangeItemAutoCraftRemainingMessage(uint count = 0)
		{
			Count = count;
		}

	}
}
