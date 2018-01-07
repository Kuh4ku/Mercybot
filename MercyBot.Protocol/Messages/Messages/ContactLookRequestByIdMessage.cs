using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ContactLookRequestByIdMessage : ContactLookRequestMessage
	{

		// Properties
		public uint PlayerId { get; set; }


		// Constructors
		public ContactLookRequestByIdMessage() { }

		public ContactLookRequestByIdMessage(uint requestId = 0, uint contactType = 0, uint playerId = 0)
		{
			RequestId = requestId;
			ContactType = contactType;
			PlayerId = playerId;
		}

	}
}
