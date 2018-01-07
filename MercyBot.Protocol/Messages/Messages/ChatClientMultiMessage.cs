using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChatClientMultiMessage : ChatAbstractClientMessage
	{

		// Properties
		public uint Channel { get; set; }


		// Constructors
		public ChatClientMultiMessage() { }

		public ChatClientMultiMessage(string content = "", uint channel = 0)
		{
			Content = content;
			Channel = channel;
		}

	}
}
