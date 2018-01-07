using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeCraftResultMessage : Message
	{

		// Properties
		public uint CraftResult { get; set; }


		// Constructors
		public ExchangeCraftResultMessage() { }

		public ExchangeCraftResultMessage(uint craftResult = 0)
		{
			CraftResult = craftResult;
		}

	}
}
