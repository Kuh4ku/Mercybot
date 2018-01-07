using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyMemberRemoveMessage : AbstractPartyEventMessage
	{

		// Properties
		public uint LeavingPlayerId { get; set; }


		// Constructors
		public PartyMemberRemoveMessage() { }

		public PartyMemberRemoveMessage(uint partyId = 0, uint leavingPlayerId = 0)
		{
			PartyId = partyId;
			LeavingPlayerId = leavingPlayerId;
		}

	}
}
