using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightInvisibilityMessage : AbstractGameActionMessage
	{

		// Properties
		public int TargetId { get; set; }
		public int State { get; set; }


		// Constructors
		public GameActionFightInvisibilityMessage() { }

		public GameActionFightInvisibilityMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, int state = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			State = state;
		}

	}
}
