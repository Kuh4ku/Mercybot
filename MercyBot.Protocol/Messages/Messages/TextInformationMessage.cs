using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TextInformationMessage : Message
	{

		// Properties
		public List<string> Parameters { get; set; }
		public uint MsgType { get; set; }
		public uint MsgId { get; set; }
        public string Text { get; set; }


		// Constructors
		public TextInformationMessage() { }

		public TextInformationMessage(uint msgType = 0, uint msgId = 0, List<string> parameters = null)
		{
			MsgType = msgType;
			MsgId = msgId;
			Parameters = parameters;
		}

	}
}
