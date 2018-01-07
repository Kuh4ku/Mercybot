using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyInvitationMessage : AbstractPartyMessage
	{

		// Properties
		public uint PartyType { get; set; }
		public uint MaxParticipants { get; set; }
		public uint FromId { get; set; }
		public string FromName { get; set; }
		public uint ToId { get; set; }


		// Constructors
		public PartyInvitationMessage() { }

		public PartyInvitationMessage(uint partyId = 0, uint partyType = 0, uint maxParticipants = 0, uint fromId = 0, string fromName = "", uint toId = 0)
		{
			PartyId = partyId;
			PartyType = partyType;
			MaxParticipants = maxParticipants;
			FromId = fromId;
			FromName = fromName;
			ToId = toId;
		}

	}
}
