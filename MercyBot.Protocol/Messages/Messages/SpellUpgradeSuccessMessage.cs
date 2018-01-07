using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class SpellUpgradeSuccessMessage : Message
	{

		// Properties
		public int SpellId { get; set; }
		public uint SpellLevel { get; set; }


		// Constructors
		public SpellUpgradeSuccessMessage() { }

		public SpellUpgradeSuccessMessage(int spellId = 0, uint spellLevel = 0)
		{
			SpellId = spellId;
			SpellLevel = spellLevel;
		}

	}
}
