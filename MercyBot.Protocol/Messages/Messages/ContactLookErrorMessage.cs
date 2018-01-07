using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ContactLookErrorMessage : Message
	{

		// Properties
		public uint RequestId { get; set; }


		// Constructors
		public ContactLookErrorMessage() { }

		public ContactLookErrorMessage(uint requestId = 0)
		{
			RequestId = requestId;
		}

	}
}
