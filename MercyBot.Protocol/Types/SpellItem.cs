using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class SpellItem : Item
	{

		// Properties
		public uint Position { get; set; }
		public int SpellId { get; set; }
		public int SpellLevel { get; set; }


		// Constructors
		public SpellItem() { }

		public SpellItem(uint position = 0, int spellId = 0, int spellLevel = 0)
		{
			Position = position;
			SpellId = spellId;
			SpellLevel = spellLevel;
		}

	}
}
