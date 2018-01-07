using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class BasicWhoIsNoMatchMessage : Message
	{

		// Properties
		public string Search { get; set; }


		// Constructors
		public BasicWhoIsNoMatchMessage() { }

		public BasicWhoIsNoMatchMessage(string search = "")
		{
			Search = search;
		}

	}
}
