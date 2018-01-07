using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChatClientPrivateWithObjectMessage : ChatClientPrivateMessage
	{

		// Properties
		public List<ObjectItem> Objects { get; set; }


		// Constructors
		public ChatClientPrivateWithObjectMessage() { }

		public ChatClientPrivateWithObjectMessage(string content = "", string receiver = "", List<ObjectItem> objects = null)
		{
			Content = content;
			Receiver = receiver;
			Objects = objects;
		}

	}
}
