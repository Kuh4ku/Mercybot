using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightReflectSpellMessage : AbstractGameActionMessage
	{

		// Properties
		public int TargetId { get; set; }


		// Constructors
		public GameActionFightReflectSpellMessage() { }

		public GameActionFightReflectSpellMessage(uint actionId = 0, int sourceId = 0, int targetId = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
		}

	}
}
