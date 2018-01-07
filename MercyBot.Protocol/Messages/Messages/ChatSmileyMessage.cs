using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChatSmileyMessage : Message
	{

		// Properties
		public int EntityId { get; set; }
		public uint SmileyId { get; set; }
		public uint AccountId { get; set; }


		// Constructors
		public ChatSmileyMessage() { }

		public ChatSmileyMessage(int entityId = 0, uint smileyId = 0, uint accountId = 0)
		{
			EntityId = entityId;
			SmileyId = smileyId;
			AccountId = accountId;
		}

	}
}
