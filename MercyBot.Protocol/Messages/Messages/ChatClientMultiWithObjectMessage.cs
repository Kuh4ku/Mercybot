using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChatClientMultiWithObjectMessage : ChatClientMultiMessage
	{

		// Properties
		public List<ObjectItem> Objects { get; set; }


		// Constructors
		public ChatClientMultiWithObjectMessage() { }

		public ChatClientMultiWithObjectMessage(string content = "", uint channel = 0, List<ObjectItem> objects = null)
		{
			Content = content;
			Channel = channel;
			Objects = objects;
		}

	}
}
