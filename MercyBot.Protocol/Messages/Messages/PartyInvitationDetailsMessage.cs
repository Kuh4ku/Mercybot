using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyInvitationDetailsMessage : AbstractPartyMessage
	{

		// Properties
		public List<PartyInvitationMemberInformations> Members { get; set; }
		public List<PartyGuestInformations> Guests { get; set; }
		public uint PartyType { get; set; }
		public uint FromId { get; set; }
		public string FromName { get; set; }
		public uint LeaderId { get; set; }


		// Constructors
		public PartyInvitationDetailsMessage() { }

		public PartyInvitationDetailsMessage(uint partyId = 0, uint partyType = 0, uint fromId = 0, string fromName = "", uint leaderId = 0, List<PartyInvitationMemberInformations> members = null, List<PartyGuestInformations> guests = null)
		{
			PartyId = partyId;
			PartyType = partyType;
			FromId = fromId;
			FromName = fromName;
			LeaderId = leaderId;
			Members = members;
			Guests = guests;
		}

	}
}
