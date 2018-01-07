using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyFollowMemberRequestMessage : AbstractPartyMessage
	{

		// Properties
		public uint PlayerId { get; set; }


		// Constructors
		public PartyFollowMemberRequestMessage() { }

		public PartyFollowMemberRequestMessage(uint partyId = 0, uint playerId = 0)
		{
			PartyId = partyId;
			PlayerId = playerId;
		}

	}
}
