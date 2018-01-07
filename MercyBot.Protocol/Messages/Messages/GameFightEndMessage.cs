using System.Collections.Generic;
using MercyBot.Protocol.Types;
using Newtonsoft.Json;
using MercyBot.Protocol.Converters;

namespace MercyBot.Protocol.Messages
{
	public class GameFightEndMessage : Message
	{

		// Properties
        [JsonConverter(typeof(TypedPropertyConverter))]
		public List<FightResultListEntry> Results { get; set; }
		public uint Duration { get; set; }
		public int AgeBonus { get; set; }
		public int LootShareLimitMalus { get; set; }


		// Constructors
		public GameFightEndMessage() { }

		public GameFightEndMessage(uint duration = 0, int ageBonus = 0, int lootShareLimitMalus = 0, List<FightResultListEntry> results = null)
		{
			Duration = duration;
			AgeBonus = ageBonus;
			LootShareLimitMalus = lootShareLimitMalus;
			Results = results;
		}

	}
}
