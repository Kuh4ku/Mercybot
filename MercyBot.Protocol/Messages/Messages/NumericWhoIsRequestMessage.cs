using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class NumericWhoIsRequestMessage : Message
	{

		// Properties
		public uint PlayerId { get; set; }


		// Constructors
		public NumericWhoIsRequestMessage() { }

		public NumericWhoIsRequestMessage(uint playerId = 0)
		{
			PlayerId = playerId;
		}

	}
}
