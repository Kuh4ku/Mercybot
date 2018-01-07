using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeOkMultiCraftMessage : Message
	{

		// Properties
		public uint InitiatorId { get; set; }
		public uint OtherId { get; set; }
		public int Role { get; set; }


		// Constructors
		public ExchangeOkMultiCraftMessage() { }

		public ExchangeOkMultiCraftMessage(uint initiatorId = 0, uint otherId = 0, int role = 0)
		{
			InitiatorId = initiatorId;
			OtherId = otherId;
			Role = role;
		}

	}
}
