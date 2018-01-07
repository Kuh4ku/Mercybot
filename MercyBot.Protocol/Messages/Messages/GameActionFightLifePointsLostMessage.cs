using System.Collections.Generic;
using MercyBot.Protocol.Types;
using Newtonsoft.Json;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightLifePointsLostMessage : AbstractGameActionMessage
	{

		// Properties
		public int TargetId { get; set; }
		public uint Loss { get; set; }
		public uint PermanentDamages { get; set; }
        [JsonProperty("_isDead")]
        public bool IsDead { get; set; }


		// Constructors
		public GameActionFightLifePointsLostMessage() { }

		public GameActionFightLifePointsLostMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, uint loss = 0, uint permanentDamages = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			Loss = loss;
			PermanentDamages = permanentDamages;
		}

	}
}
