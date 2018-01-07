using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ContactLookRequestMessage : Message
	{

		// Properties
		public uint RequestId { get; set; }
		public uint ContactType { get; set; }


		// Constructors
		public ContactLookRequestMessage() { }

		public ContactLookRequestMessage(uint requestId = 0, uint contactType = 0)
		{
			RequestId = requestId;
			ContactType = contactType;
		}

	}
}
