using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChatAbstractClientMessage : Message
	{

		// Properties
		public string Content { get; set; }


		// Constructors
		public ChatAbstractClientMessage() { }

		public ChatAbstractClientMessage(string content = "")
		{
			Content = content;
		}

	}
}
