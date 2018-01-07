using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ShortcutSpell : Shortcut
	{

		// Properties
		public uint SpellId { get; set; }


		// Constructors
		public ShortcutSpell() { }

		public ShortcutSpell(uint slot = 0, uint spellId = 0)
		{
			Slot = slot;
			SpellId = spellId;
		}

	}
}
