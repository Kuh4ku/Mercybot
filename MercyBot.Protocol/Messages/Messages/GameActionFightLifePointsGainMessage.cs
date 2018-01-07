using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightLifePointsGainMessage : AbstractGameActionMessage
	{

		// Properties
		public int TargetId { get; set; }
		public uint Delta { get; set; }


		// Constructors
		public GameActionFightLifePointsGainMessage() { }

		public GameActionFightLifePointsGainMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, uint delta = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			Delta = delta;
		}

	}
}
