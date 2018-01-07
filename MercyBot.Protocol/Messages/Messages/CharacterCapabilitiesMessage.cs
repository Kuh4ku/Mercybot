using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterCapabilitiesMessage : Message
	{

		// Properties
		public uint GuildEmblemSymbolCategories { get; set; }


		// Constructors
		public CharacterCapabilitiesMessage() { }

		public CharacterCapabilitiesMessage(uint guildEmblemSymbolCategories = 0)
		{
			GuildEmblemSymbolCategories = guildEmblemSymbolCategories;
		}

	}
}
