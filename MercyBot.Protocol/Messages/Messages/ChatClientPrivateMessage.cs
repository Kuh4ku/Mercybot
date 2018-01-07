using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChatClientPrivateMessage : ChatAbstractClientMessage
	{

		// Properties
		public string Receiver { get; set; }


		// Constructors
		public ChatClientPrivateMessage() { }

		public ChatClientPrivateMessage(string content = "", string receiver = "")
		{
			Content = content;
			Receiver = receiver;
		}

	}
}
