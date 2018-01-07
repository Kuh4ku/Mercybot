using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyNewGuestMessage : AbstractPartyEventMessage
	{

		// Properties
		public PartyGuestInformations Guest { get; set; }


		// Constructors
		public PartyNewGuestMessage() { }

		public PartyNewGuestMessage(uint partyId = 0, PartyGuestInformations guest = null)
		{
			PartyId = partyId;
			Guest = guest;
		}

	}
}
