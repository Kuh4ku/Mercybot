using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyFollowThisMemberRequestMessage : PartyFollowMemberRequestMessage
	{

		// Properties
		public bool Enabled { get; set; }


		// Constructors
		public PartyFollowThisMemberRequestMessage() { }

		public PartyFollowThisMemberRequestMessage(uint partyId = 0, uint playerId = 0, bool enabled = false)
		{
			PartyId = partyId;
			PlayerId = playerId;
			Enabled = enabled;
		}

	}
}
