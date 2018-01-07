using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyAcceptInvitationMessage : AbstractPartyMessage
	{

		// Constructors
		public PartyAcceptInvitationMessage() { }

		public PartyAcceptInvitationMessage(uint partyId = 0)
		{
			PartyId = partyId;
		}

	}
}
