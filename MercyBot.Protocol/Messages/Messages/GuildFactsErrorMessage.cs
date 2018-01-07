using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildFactsErrorMessage : Message
	{

		// Properties
		public uint GuildId { get; set; }


		// Constructors
		public GuildFactsErrorMessage() { }

		public GuildFactsErrorMessage(uint guildId = 0)
		{
			GuildId = guildId;
		}

	}
}
