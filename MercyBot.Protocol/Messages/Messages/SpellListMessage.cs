using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class SpellListMessage : Message
	{

		// Properties
		public List<SpellItem> Spells { get; set; }
		public bool SpellPrevisualization { get; set; }


		// Constructors
		public SpellListMessage() { }

		public SpellListMessage(bool spellPrevisualization = false, List<SpellItem> spells = null)
		{
			SpellPrevisualization = spellPrevisualization;
			Spells = spells;
		}

	}
}
