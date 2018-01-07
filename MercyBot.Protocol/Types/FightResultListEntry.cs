using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightResultListEntry
	{

		// Properties
		public uint Outcome { get; set; }
		public FightLoot Rewards { get; set; }


		// Constructors
		public FightResultListEntry() { }

		public FightResultListEntry(uint outcome = 0, FightLoot rewards = null)
		{
			Outcome = outcome;
			Rewards = rewards;
		}

	}
}
