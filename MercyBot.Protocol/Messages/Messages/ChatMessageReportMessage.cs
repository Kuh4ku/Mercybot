using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChatMessageReportMessage : Message
	{

		// Properties
		public string SenderName { get; set; }
		public string Content { get; set; }
		public uint Timestamp { get; set; }
		public uint Channel { get; set; }
		public string Fingerprint { get; set; }
		public uint Reason { get; set; }


		// Constructors
		public ChatMessageReportMessage() { }

		public ChatMessageReportMessage(string senderName = "", string content = "", uint timestamp = 0, uint channel = 0, string fingerprint = "", uint reason = 0)
		{
			SenderName = senderName;
			Content = content;
			Timestamp = timestamp;
			Channel = channel;
			Fingerprint = fingerprint;
			Reason = reason;
		}

	}
}
