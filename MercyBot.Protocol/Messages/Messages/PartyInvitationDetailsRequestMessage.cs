using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyInvitationDetailsRequestMessage : AbstractPartyMessage
	{

		// Constructors
		public PartyInvitationDetailsRequestMessage() { }

		public PartyInvitationDetailsRequestMessage(uint partyId = 0)
		{
			PartyId = partyId;
		}

	}
}
