using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildFactsRequestMessage : Message
	{

		// Properties
		public uint GuildId { get; set; }


		// Constructors
		public GuildFactsRequestMessage() { }

		public GuildFactsRequestMessage(uint guildId = 0)
		{
			GuildId = guildId;
		}

	}
}
