using System.Collections.Generic;
using MercyBot.Protocol.Types;
using Newtonsoft.Json;
using MercyBot.Protocol.Converters;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightSummonMessage : AbstractGameActionMessage
	{

        // Properties
        [JsonConverter(typeof(TypedPropertyConverter))]
        public GameFightFighterInformations Summon { get; set; }


		// Constructors
		public GameActionFightSummonMessage() { }

		public GameActionFightSummonMessage(uint actionId = 0, int sourceId = 0, GameFightFighterInformations summon = null)
		{
			ActionId = actionId;
			SourceId = sourceId;
			Summon = summon;
		}

	}
}
