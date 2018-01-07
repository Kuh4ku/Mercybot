using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AbstractGameActionWithAckMessage : AbstractGameActionMessage
	{

		// Properties
		public int WaitAckId { get; set; }


		// Constructors
		public AbstractGameActionWithAckMessage() { }

		public AbstractGameActionWithAckMessage(uint actionId = 0, int sourceId = 0, int waitAckId = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
			WaitAckId = waitAckId;
		}

	}
}
