using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class IgnoredAddedMessage : Message
	{

		// Properties
		public IgnoredInformations IgnoreAdded { get; set; }
		public bool Session { get; set; }


		// Constructors
		public IgnoredAddedMessage() { }

		public IgnoredAddedMessage(IgnoredInformations ignoreAdded = null, bool session = false)
		{
			IgnoreAdded = ignoreAdded;
			Session = session;
		}

	}
}
