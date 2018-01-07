using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChatServerCopyWithObjectMessage : ChatServerCopyMessage
	{

		// Properties
		public List<ObjectItem> Objects { get; set; }


		// Constructors
		public ChatServerCopyWithObjectMessage() { }

		public ChatServerCopyWithObjectMessage(uint channel = 0, string content = "", uint timestamp = 0, string fingerprint = "", uint receiverId = 0, string receiverName = "", List<ObjectItem> objects = null)
		{
			Channel = channel;
			Content = content;
			Timestamp = timestamp;
			Fingerprint = fingerprint;
			ReceiverId = receiverId;
			ReceiverName = receiverName;
			Objects = objects;
		}

	}
}
