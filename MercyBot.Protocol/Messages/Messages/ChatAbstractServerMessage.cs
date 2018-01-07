using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChatAbstractServerMessage : Message
	{

		// Properties
		public uint Channel { get; set; }
		public string Content { get; set; }
		public uint Timestamp { get; set; }
		public string Fingerprint { get; set; }


		// Constructors
		public ChatAbstractServerMessage() { }

		public ChatAbstractServerMessage(uint channel = 0, string content = "", uint timestamp = 0, string fingerprint = "")
		{
			Channel = channel;
			Content = content;
			Timestamp = timestamp;
			Fingerprint = fingerprint;
		}

	}
}
