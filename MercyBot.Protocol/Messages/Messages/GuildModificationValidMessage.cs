using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildModificationValidMessage : Message
	{

		// Properties
		public string GuildName { get; set; }
		public GuildEmblem GuildEmblem { get; set; }


		// Constructors
		public GuildModificationValidMessage() { }

		public GuildModificationValidMessage(string guildName = "", GuildEmblem guildEmblem = null)
		{
			GuildName = guildName;
			GuildEmblem = guildEmblem;
		}

	}
}
