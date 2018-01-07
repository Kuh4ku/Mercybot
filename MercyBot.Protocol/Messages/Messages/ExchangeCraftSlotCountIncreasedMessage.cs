using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeCraftSlotCountIncreasedMessage : Message
	{

		// Properties
		public uint NewMaxSlot { get; set; }


		// Constructors
		public ExchangeCraftSlotCountIncreasedMessage() { }

		public ExchangeCraftSlotCountIncreasedMessage(uint newMaxSlot = 0)
		{
			NewMaxSlot = newMaxSlot;
		}

	}
}
