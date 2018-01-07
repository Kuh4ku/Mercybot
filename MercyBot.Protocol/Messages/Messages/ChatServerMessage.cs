using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChatServerMessage : ChatAbstractServerMessage
	{

		// Properties
		public int SenderId { get; set; }
		public string SenderName { get; set; }
		public int SenderAccountId { get; set; }


		// Constructors
		public ChatServerMessage() { }

		public ChatServerMessage(uint channel = 0, string content = "", uint timestamp = 0, string fingerprint = "", int senderId = 0, string senderName = "", int senderAccountId = 0)
		{
			Channel = channel;
			Content = content;
			Timestamp = timestamp;
			Fingerprint = fingerprint;
			SenderId = senderId;
			SenderName = senderName;
			SenderAccountId = senderAccountId;
		}

	}
}
