using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class NumericWhoIsMessage : Message
	{

		// Properties
		public uint PlayerId { get; set; }
		public uint AccountId { get; set; }


		// Constructors
		public NumericWhoIsMessage() { }

		public NumericWhoIsMessage(uint playerId = 0, uint accountId = 0)
		{
			PlayerId = playerId;
			AccountId = accountId;
		}

	}
}
