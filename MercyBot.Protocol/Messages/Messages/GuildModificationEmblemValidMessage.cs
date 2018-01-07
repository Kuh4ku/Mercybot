using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildModificationEmblemValidMessage : Message
	{

		// Properties
		public GuildEmblem GuildEmblem { get; set; }


		// Constructors
		public GuildModificationEmblemValidMessage() { }

		public GuildModificationEmblemValidMessage(GuildEmblem guildEmblem = null)
		{
			GuildEmblem = guildEmblem;
		}

	}
}
