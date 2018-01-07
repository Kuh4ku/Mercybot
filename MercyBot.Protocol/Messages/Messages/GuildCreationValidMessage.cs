using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildCreationValidMessage : Message
	{

		// Properties
		public string GuildName { get; set; }
		public GuildEmblem GuildEmblem { get; set; }


		// Constructors
		public GuildCreationValidMessage() { }

		public GuildCreationValidMessage(string guildName = "", GuildEmblem guildEmblem = null)
		{
			GuildName = guildName;
			GuildEmblem = guildEmblem;
		}

	}
}
