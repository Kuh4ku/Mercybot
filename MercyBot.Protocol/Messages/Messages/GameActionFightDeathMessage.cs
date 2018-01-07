using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightDeathMessage : AbstractGameActionMessage
	{

		// Properties
		public int TargetId { get; set; }


		// Constructors
		public GameActionFightDeathMessage() { }

		public GameActionFightDeathMessage(uint actionId = 0, int sourceId = 0, int targetId = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
		}

	}
}
