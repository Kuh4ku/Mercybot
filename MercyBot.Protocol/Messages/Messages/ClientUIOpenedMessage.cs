using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ClientUIOpenedMessage : Message
	{

		// Properties
		public uint Type { get; set; }


		// Constructors
		public ClientUIOpenedMessage() { }

		public ClientUIOpenedMessage(uint type = 0)
		{
			Type = type;
		}

	}
}
