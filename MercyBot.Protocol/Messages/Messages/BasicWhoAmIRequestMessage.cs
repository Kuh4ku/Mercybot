using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class BasicWhoAmIRequestMessage : Message
	{

		// Properties
		public bool Verbose { get; set; }


		// Constructors
		public BasicWhoAmIRequestMessage() { }

		public BasicWhoAmIRequestMessage(bool verbose = false)
		{
			Verbose = verbose;
		}

	}
}
