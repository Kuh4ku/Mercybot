using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyCancelInvitationNotificationMessage : AbstractPartyEventMessage
	{

		// Properties
		public uint CancelerId { get; set; }
		public uint GuestId { get; set; }


		// Constructors
		public PartyCancelInvitationNotificationMessage() { }

		public PartyCancelInvitationNotificationMessage(uint partyId = 0, uint cancelerId = 0, uint guestId = 0)
		{
			PartyId = partyId;
			CancelerId = cancelerId;
			GuestId = guestId;
		}

	}
}
