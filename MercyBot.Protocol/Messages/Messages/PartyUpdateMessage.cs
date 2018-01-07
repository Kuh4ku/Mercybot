using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyUpdateMessage : AbstractPartyEventMessage
	{

		// Properties
		public PartyMemberInformations MemberInformations { get; set; }


		// Constructors
		public PartyUpdateMessage() { }

		public PartyUpdateMessage(uint partyId = 0, PartyMemberInformations memberInformations = null)
		{
			PartyId = partyId;
			MemberInformations = memberInformations;
		}

	}
}
