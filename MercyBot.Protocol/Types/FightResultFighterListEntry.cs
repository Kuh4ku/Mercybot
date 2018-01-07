using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightResultFighterListEntry : FightResultListEntry
	{

		// Properties
		public int Id { get; set; }
		public bool Alive { get; set; }


		// Constructors
		public FightResultFighterListEntry() { }

		public FightResultFighterListEntry(uint outcome = 0, FightLoot rewards = null, int id = 0, bool alive = false)
		{
			Outcome = outcome;
			Rewards = rewards;
			Id = id;
			Alive = alive;
		}

	}
}
