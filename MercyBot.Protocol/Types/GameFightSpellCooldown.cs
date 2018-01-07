using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameFightSpellCooldown
	{

		// Properties
		public int SpellId { get; set; }
		public uint Cooldown { get; set; }


		// Constructors
		public GameFightSpellCooldown() { }

		public GameFightSpellCooldown(int spellId = 0, uint cooldown = 0)
		{
			SpellId = spellId;
			Cooldown = cooldown;
		}

	}
}
