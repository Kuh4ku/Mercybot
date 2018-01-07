using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightMarkCellsMessage : AbstractGameActionMessage
	{

		// Properties
		public GameActionMark Mark { get; set; }


		// Constructors
		public GameActionFightMarkCellsMessage() { }

		public GameActionFightMarkCellsMessage(uint actionId = 0, int sourceId = 0, GameActionMark mark = null)
		{
			ActionId = actionId;
			SourceId = sourceId;
			Mark = mark;
		}

	}
}
