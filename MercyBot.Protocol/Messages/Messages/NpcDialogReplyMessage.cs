using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class NpcDialogReplyMessage : Message
	{

		// Properties
		public uint ReplyId { get; set; }


		// Constructors
		public NpcDialogReplyMessage() { }

		public NpcDialogReplyMessage(uint replyId = 0)
		{
			ReplyId = replyId;
		}

	}
}
