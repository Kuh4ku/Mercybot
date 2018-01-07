using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChatSmileyRequestMessage : Message
	{

		// Properties
		public uint SmileyId { get; set; }


		// Constructors
		public ChatSmileyRequestMessage() { }

		public ChatSmileyRequestMessage(uint smileyId = 0)
		{
			SmileyId = smileyId;
		}

	}
}
