using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class HouseGuildRightsMessage : Message
	{

		// Properties
		public uint HouseId { get; set; }
		public GuildInformations GuildInfo { get; set; }
		public uint Rights { get; set; }


		// Constructors
		public HouseGuildRightsMessage() { }

		public HouseGuildRightsMessage(uint houseId = 0, GuildInformations guildInfo = null, uint rights = 0)
		{
			HouseId = houseId;
			GuildInfo = guildInfo;
			Rights = rights;
		}

	}
}
