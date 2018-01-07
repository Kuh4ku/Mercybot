using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class IgnoredDeleteResultMessage : Message
	{

		// Properties
		public bool Success { get; set; }
		public string Name { get; set; }
		public bool Session { get; set; }


		// Constructors
		public IgnoredDeleteResultMessage() { }

		public IgnoredDeleteResultMessage(bool success = false, string name = "", bool session = false)
		{
			Success = success;
			Name = name;
			Session = session;
		}

	}
}
