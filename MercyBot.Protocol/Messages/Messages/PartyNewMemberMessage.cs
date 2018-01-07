using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyNewMemberMessage : PartyUpdateMessage
	{

		// Constructors
		public PartyNewMemberMessage() { }

		public PartyNewMemberMessage(uint partyId = 0, PartyMemberInformations memberInformations = null)
		{
			PartyId = partyId;
			MemberInformations = memberInformations;
		}

	}
}
