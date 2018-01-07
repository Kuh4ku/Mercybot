using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AbstractGameActionFightTargetedAbilityMessage : AbstractGameActionMessage
	{

		// Properties
		public int TargetId { get; set; }
		public int DestinationCellId { get; set; }
		public uint Critical { get; set; }
		public bool SilentCast { get; set; }


		// Constructors
		public AbstractGameActionFightTargetedAbilityMessage() { }

		public AbstractGameActionFightTargetedAbilityMessage(uint actionId = 0, int sourceId = 0, int targetId = 0, int destinationCellId = 0, uint critical = 1, bool silentCast = false)
		{
			ActionId = actionId;
			SourceId = sourceId;
			TargetId = targetId;
			DestinationCellId = destinationCellId;
			Critical = critical;
			SilentCast = silentCast;
		}

	}
}
