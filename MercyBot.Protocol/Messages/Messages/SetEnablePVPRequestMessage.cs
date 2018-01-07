using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class SetEnablePVPRequestMessage : Message
	{

		// Properties
		public bool Enable { get; set; }


		// Constructors
		public SetEnablePVPRequestMessage() { }

		public SetEnablePVPRequestMessage(bool enable = false)
		{
			Enable = enable;
		}

	}
}
