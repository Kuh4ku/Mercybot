using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class IgnoredAddRequestMessage : Message
	{

		// Properties
		public string Name { get; set; }
		public bool Session { get; set; }


		// Constructors
		public IgnoredAddRequestMessage() { }

		public IgnoredAddRequestMessage(string name = "", bool session = false)
		{
			Name = name;
			Session = session;
		}

	}
}
