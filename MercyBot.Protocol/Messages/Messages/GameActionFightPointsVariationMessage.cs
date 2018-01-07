using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightPointsVariationMessage : AbstractGameActionMessage
	{

		// Properties
		public int TargetId { get; set; }
		public int Delta { get; set; }


		// Constructors
		public GameActionFightPointsVariationMessage() { }

		public GameActionFightPointsVariationMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, int delta = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			Delta = delta;
		}

	}
}
