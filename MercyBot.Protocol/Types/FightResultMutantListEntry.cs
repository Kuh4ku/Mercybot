using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightResultMutantListEntry : FightResultFighterListEntry
	{

		// Properties
		public uint Level { get; set; }


		// Constructors
		public FightResultMutantListEntry() { }

		public FightResultMutantListEntry(uint outcome = 0, FightLoot rewards = null, int id = 0, bool alive = false, uint level = 0)
		{
			Outcome = outcome;
			Rewards = rewards;
			Id = id;
			Alive = alive;
			Level = level;
		}

	}
}
