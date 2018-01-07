using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightExchangePositionsMessage : AbstractGameActionMessage
	{

		// Properties
		public int TargetId { get; set; }
		public int CasterCellId { get; set; }
		public int TargetCellId { get; set; }


		// Constructors
		public GameActionFightExchangePositionsMessage() { }

		public GameActionFightExchangePositionsMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, int casterCellId = 0, int targetCellId = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			CasterCellId = casterCellId;
			TargetCellId = targetCellId;
		}

	}
}
