using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildLevelUpMessage : Message
	{

		// Properties
		public uint NewLevel { get; set; }


		// Constructors
		public GuildLevelUpMessage() { }

		public GuildLevelUpMessage(uint newLevel = 0)
		{
			NewLevel = newLevel;
		}

	}
}
