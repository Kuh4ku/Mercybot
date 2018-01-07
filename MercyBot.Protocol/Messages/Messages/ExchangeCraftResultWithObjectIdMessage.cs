using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeCraftResultWithObjectIdMessage : ExchangeCraftResultMessage
	{

		// Properties
		public uint ObjectGenericId { get; set; }


		// Constructors
		public ExchangeCraftResultWithObjectIdMessage() { }

		public ExchangeCraftResultWithObjectIdMessage(uint craftResult = 0, uint objectGenericId = 0)
		{
			CraftResult = craftResult;
			ObjectGenericId = objectGenericId;
		}

	}
}
