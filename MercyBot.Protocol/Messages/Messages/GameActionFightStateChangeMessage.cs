using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightStateChangeMessage : AbstractGameActionMessage
	{

		// Properties
		public int TargetId { get; set; }
		public int StateId { get; set; }
		public bool Active { get; set; }


		// Constructors
		public GameActionFightStateChangeMessage() { }

		public GameActionFightStateChangeMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, int stateId = 0, bool active = false)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			StateId = stateId;
			Active = active;
		}

	}
}
