using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GuildInformations : BasicGuildInformations
	{

		// Properties
		public GuildEmblem GuildEmblem { get; set; }


		// Constructors
		public GuildInformations() { }

		public GuildInformations(uint guildId = 0, string guildName = "", GuildEmblem guildEmblem = null)
		{
			GuildId = guildId;
			GuildName = guildName;
			GuildEmblem = guildEmblem;
		}

	}
}
