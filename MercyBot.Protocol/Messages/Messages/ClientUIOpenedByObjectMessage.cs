using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ClientUIOpenedByObjectMessage : ClientUIOpenedMessage
	{

		// Properties
		public uint Uid { get; set; }


		// Constructors
		public ClientUIOpenedByObjectMessage() { }

		public ClientUIOpenedByObjectMessage(uint type = 0, uint uid = 0)
		{
			Type = type;
			Uid = uid;
		}

	}
}
