using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightCarryCharacterMessage : AbstractGameActionMessage
	{

		// Properties
		public int TargetId { get; set; }
		public int CellId { get; set; }


		// Constructors
		public GameActionFightCarryCharacterMessage() { }

		public GameActionFightCarryCharacterMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, int cellId = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			CellId = cellId;
		}

	}
}
