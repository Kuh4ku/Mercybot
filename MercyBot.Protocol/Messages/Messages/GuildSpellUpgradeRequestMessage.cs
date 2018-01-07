using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildSpellUpgradeRequestMessage : Message
	{

		// Properties
		public uint SpellId { get; set; }


		// Constructors
		public GuildSpellUpgradeRequestMessage() { }

		public GuildSpellUpgradeRequestMessage(uint spellId = 0)
		{
			SpellId = spellId;
		}

	}
}
