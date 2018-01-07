using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AbstractGameActionMessage : Message
	{

		// Properties
		public uint ActionId { get; set; }
		public int SourceId { get; set; }


		// Constructors
		public AbstractGameActionMessage() { }

		public AbstractGameActionMessage(uint actionId = 0, int sourceId = 0)
		{
			ActionId = actionId;
			SourceId = sourceId;
		}

	}
}
