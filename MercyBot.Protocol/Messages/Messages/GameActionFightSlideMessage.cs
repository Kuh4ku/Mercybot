using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightSlideMessage : AbstractGameActionMessage
	{

		// Properties
		public int TargetId { get; set; }
		public int StartCellId { get; set; }
		public int EndCellId { get; set; }


		// Constructors
		public GameActionFightSlideMessage() { }

		public GameActionFightSlideMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, int startCellId = 0, int endCellId = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			StartCellId = startCellId;
			EndCellId = endCellId;
		}

	}
}
