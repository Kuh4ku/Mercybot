using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class BasicWhoIsRequestMessage : Message
	{

		// Properties
		public bool Verbose { get; set; }
		public string Search { get; set; }


		// Constructors
		public BasicWhoIsRequestMessage() { }

		public BasicWhoIsRequestMessage(bool verbose = false, string search = "")
		{
			Verbose = verbose;
			Search = search;
		}

	}
}
