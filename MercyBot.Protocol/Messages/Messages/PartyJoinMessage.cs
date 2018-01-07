using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyJoinMessage : AbstractPartyMessage
	{

		// Properties
		public List<PartyMemberInformations> Members { get; set; }
		public List<PartyGuestInformations> Guests { get; set; }
		public uint PartyType { get; set; }
		public uint PartyLeaderId { get; set; }
		public uint MaxParticipants { get; set; }
		public bool Restricted { get; set; }


		// Constructors
		public PartyJoinMessage() { }

		public PartyJoinMessage(uint partyId = 0, uint partyType = 0, uint partyLeaderId = 0, uint maxParticipants = 0, bool restricted = false, List<PartyMemberInformations> members = null, List<PartyGuestInformations> guests = null)
		{
			PartyId = partyId;
			PartyType = partyType;
			PartyLeaderId = partyLeaderId;
			MaxParticipants = maxParticipants;
			Restricted = restricted;
			Members = members;
			Guests = guests;
		}

	}
}
