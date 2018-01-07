using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildHouseTeleportRequestMessage : Message
	{

		// Properties
		public uint HouseId { get; set; }


		// Constructors
		public GuildHouseTeleportRequestMessage() { }

		public GuildHouseTeleportRequestMessage(uint houseId = 0)
		{
			HouseId = houseId;
		}

	}
}
