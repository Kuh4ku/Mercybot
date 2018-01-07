using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class EntityTalkMessage : Message
	{

		// Properties
		public List<string> Parameters { get; set; }
		public int EntityId { get; set; }
		public uint TextId { get; set; }


		// Constructors
		public EntityTalkMessage() { }

		public EntityTalkMessage(int entityId = 0, uint textId = 0, List<string> parameters = null)
		{
			EntityId = entityId;
			TextId = textId;
			Parameters = parameters;
		}

	}
}
