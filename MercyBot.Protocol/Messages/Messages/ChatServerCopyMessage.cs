using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChatServerCopyMessage : ChatAbstractServerMessage
	{

		// Properties
		public uint ReceiverId { get; set; }
		public string ReceiverName { get; set; }


		// Constructors
		public ChatServerCopyMessage() { }

		public ChatServerCopyMessage(uint channel = 0, string content = "", uint timestamp = 0, string fingerprint = "", uint receiverId = 0, string receiverName = "")
		{
			Channel = channel;
			Content = content;
			Timestamp = timestamp;
			Fingerprint = fingerprint;
			ReceiverId = receiverId;
			ReceiverName = receiverName;
		}

	}
}
