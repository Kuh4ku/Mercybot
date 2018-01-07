using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class SystemMessageDisplayMessage : Message
	{

		// Properties
		public List<string> Parameters { get; set; }
		public bool HangUp { get; set; }
		public uint MsgId { get; set; }


		// Constructors
		public SystemMessageDisplayMessage() { }

		public SystemMessageDisplayMessage(bool hangUp = false, uint msgId = 0, List<string> parameters = null)
		{
			HangUp = hangUp;
			MsgId = msgId;
			Parameters = parameters;
		}

	}
}
