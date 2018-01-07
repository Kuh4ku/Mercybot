using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChatServerWithObjectMessage : ChatServerMessage
	{

		// Properties
		public List<ObjectItem> Objects { get; set; }


		// Constructors
		public ChatServerWithObjectMessage() { }

		public ChatServerWithObjectMessage(uint channel = 0, string content = "", uint timestamp = 0, string fingerprint = "", int senderId = 0, string senderName = "", int senderAccountId = 0, List<ObjectItem> objects = null)
		{
			Channel = channel;
			Content = content;
			Timestamp = timestamp;
			Fingerprint = fingerprint;
			SenderId = senderId;
			SenderName = senderName;
			SenderAccountId = senderAccountId;
			Objects = objects;
		}

	}
}
