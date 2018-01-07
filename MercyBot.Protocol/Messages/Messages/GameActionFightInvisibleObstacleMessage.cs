using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightInvisibleObstacleMessage : AbstractGameActionMessage
	{

		// Properties
		public uint SourceSpellId { get; set; }


		// Constructors
		public GameActionFightInvisibleObstacleMessage() { }

		public GameActionFightInvisibleObstacleMessage(uint actionId = 0, int sourceId = 0, uint sourceSpellId = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			SourceSpellId = sourceSpellId;
		}

	}
}
