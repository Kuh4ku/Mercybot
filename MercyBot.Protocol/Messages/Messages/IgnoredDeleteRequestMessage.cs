using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class IgnoredDeleteRequestMessage : Message
	{

		// Properties
		public uint AccountId { get; set; }
		public bool Session { get; set; }


		// Constructors
		public IgnoredDeleteRequestMessage() { }

		public IgnoredDeleteRequestMessage(uint accountId = 0, bool session = false)
		{
			AccountId = accountId;
			Session = session;
		}

	}
}
