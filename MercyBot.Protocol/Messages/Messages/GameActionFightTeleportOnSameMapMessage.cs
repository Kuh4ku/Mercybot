using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightTeleportOnSameMapMessage : AbstractGameActionMessage
	{

		// Properties
		public int TargetId { get; set; }
		public int CellId { get; set; }


		// Constructors
		public GameActionFightTeleportOnSameMapMessage() { }

		public GameActionFightTeleportOnSameMapMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, int cellId = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			CellId = cellId;
		}

	}
}
