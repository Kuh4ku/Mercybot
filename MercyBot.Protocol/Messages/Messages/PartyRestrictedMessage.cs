using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyRestrictedMessage : AbstractPartyMessage
	{

		// Properties
		public bool Restricted { get; set; }


		// Constructors
		public PartyRestrictedMessage() { }

		public PartyRestrictedMessage(uint partyId = 0, bool restricted = false)
		{
			PartyId = partyId;
			Restricted = restricted;
		}

	}
}
