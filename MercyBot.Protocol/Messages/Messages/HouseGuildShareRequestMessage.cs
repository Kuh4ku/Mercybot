using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class HouseGuildShareRequestMessage : Message
	{

		// Properties
		public bool Enable { get; set; }
		public uint Rights { get; set; }


		// Constructors
		public HouseGuildShareRequestMessage() { }

		public HouseGuildShareRequestMessage(bool enable = false, uint rights = 0)
		{
			Enable = enable;
			Rights = rights;
		}

	}
}
