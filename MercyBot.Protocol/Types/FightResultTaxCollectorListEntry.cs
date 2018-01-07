using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightResultTaxCollectorListEntry : FightResultFighterListEntry
	{

		// Properties
		public uint Level { get; set; }
		public BasicGuildInformations GuildInfo { get; set; }
		public int ExperienceForGuild { get; set; }


		// Constructors
		public FightResultTaxCollectorListEntry() { }

		public FightResultTaxCollectorListEntry(uint outcome = 0, FightLoot rewards = null, int id = 0, bool alive = false, uint level = 0, BasicGuildInformations guildInfo = null, int experienceForGuild = 0)
		{
			Outcome = outcome;
			Rewards = rewards;
			Id = id;
			Alive = alive;
			Level = level;
			GuildInfo = guildInfo;
			ExperienceForGuild = experienceForGuild;
		}

	}
}
