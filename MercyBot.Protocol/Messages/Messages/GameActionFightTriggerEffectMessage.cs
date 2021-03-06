using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightTriggerEffectMessage : GameActionFightDispellEffectMessage
	{

		// Constructors
		public GameActionFightTriggerEffectMessage() { }

		public GameActionFightTriggerEffectMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, uint boostUID = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			BoostUID = boostUID;
		}

	}
}
