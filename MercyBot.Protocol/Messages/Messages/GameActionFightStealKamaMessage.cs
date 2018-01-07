using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameActionFightStealKamaMessage : AbstractGameActionMessage
	{

		// Properties
		public int TargetId { get; set; }
		public uint Amount { get; set; }


		// Constructors
		public GameActionFightStealKamaMessage() { }

		public GameActionFightStealKamaMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, uint amount = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			Amount = amount;
		}

	}
}
