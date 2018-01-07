using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class SpellUpgradeRequestMessage : Message
	{

		// Properties
		public uint SpellId { get; set; }
		public uint SpellLevel { get; set; }


		// Constructors
		public SpellUpgradeRequestMessage() { }

		public SpellUpgradeRequestMessage(uint spellId = 0, uint spellLevel = 0)
		{
			SpellId = spellId;
			SpellLevel = spellLevel;
		}

	}
}
