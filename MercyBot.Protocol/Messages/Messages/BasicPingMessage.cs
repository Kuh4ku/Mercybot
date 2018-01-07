using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class BasicPingMessage : Message
	{

		// Properties
		public bool Quiet { get; set; }


		// Constructors
		public BasicPingMessage() { }

		public BasicPingMessage(bool quiet = false)
		{
			Quiet = quiet;
		}

	}
}
