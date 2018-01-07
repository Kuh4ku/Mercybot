using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildModificationNameValidMessage : Message
	{

		// Properties
		public string GuildName { get; set; }


		// Constructors
		public GuildModificationNameValidMessage() { }

		public GuildModificationNameValidMessage(string guildName = "")
		{
			GuildName = guildName;
		}

	}
}
