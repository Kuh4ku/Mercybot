using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildListMessage : Message
	{

		// Properties
		public List<GuildInformations> Guilds { get; set; }


		// Constructors
		public GuildListMessage() { }

		public GuildListMessage(List<GuildInformations> guilds = null)
		{
			Guilds = guilds;
		}

	}
}
