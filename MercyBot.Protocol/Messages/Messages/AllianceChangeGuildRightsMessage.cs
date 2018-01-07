using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceChangeGuildRightsMessage : Message
	{

		// Properties
		public uint GuildId { get; set; }
		public uint Rights { get; set; }


		// Constructors
		public AllianceChangeGuildRightsMessage() { }

		public AllianceChangeGuildRightsMessage(uint guildId = 0, uint rights = 0)
		{
			GuildId = guildId;
			Rights = rights;
		}

	}
}
