using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class LocalizedChatSmileyMessage : ChatSmileyMessage
	{

		// Properties
		public uint CellId { get; set; }


		// Constructors
		public LocalizedChatSmileyMessage() { }

		public LocalizedChatSmileyMessage(int entityId = 0, uint smileyId = 0, uint accountId = 0, uint cellId = 0)
		{
			EntityId = entityId;
			SmileyId = smileyId;
			AccountId = accountId;
			CellId = cellId;
		}

	}
}
