using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightUnmarkCellsMessage : AbstractGameActionMessage
	{

		// Properties
		public int MarkId { get; set; }


		// Constructors
		public GameActionFightUnmarkCellsMessage() { }

		public GameActionFightUnmarkCellsMessage(uint actionId = 0, int sourceId = 0, int markId = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			MarkId = markId;
		}

	}
}
