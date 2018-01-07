using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AcquaintanceServerListMessage : Message
	{

		// Properties
		public List<int> Servers { get; set; }


		// Constructors
		public AcquaintanceServerListMessage() { }

		public AcquaintanceServerListMessage(List<int> servers = null)
		{
			Servers = servers;
		}

	}
}
