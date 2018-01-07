using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightLifeAndShieldPointsLostMessage : GameActionFightLifePointsLostMessage
	{

		// Properties
		public uint ShieldLoss { get; set; }


		// Constructors
		public GameActionFightLifeAndShieldPointsLostMessage() { }

		public GameActionFightLifeAndShieldPointsLostMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, uint loss = 0, uint permanentDamages = 0, uint shieldLoss = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			Loss = loss;
			PermanentDamages = permanentDamages;
			ShieldLoss = shieldLoss;
		}

	}
}
