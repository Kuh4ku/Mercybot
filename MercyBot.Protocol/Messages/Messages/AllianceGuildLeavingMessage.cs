using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceGuildLeavingMessage : Message
	{

		// Properties
		public bool Kicked { get; set; }
		public int GuildId { get; set; }


		// Constructors
		public AllianceGuildLeavingMessage() { }

		public AllianceGuildLeavingMessage(bool kicked = false, int guildId = 0)
		{
			Kicked = kicked;
			GuildId = guildId;
		}

	}
}
