using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightResultPlayerListEntry : FightResultFighterListEntry
	{

		// Properties
		public List<FightResultAdditionalData> Additional { get; set; }
		public uint Level { get; set; }


		// Constructors
		public FightResultPlayerListEntry() { }

		public FightResultPlayerListEntry(uint outcome = 0, FightLoot rewards = null, int id = 0, bool alive = false, uint level = 0, List<FightResultAdditionalData> additional = null)
		{
			Outcome = outcome;
			Rewards = rewards;
			Id = id;
			Alive = alive;
			Level = level;
			Additional = additional;
		}

	}
}
