using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyStopFollowRequestMessage : AbstractPartyMessage
	{

		// Constructors
		public PartyStopFollowRequestMessage() { }

		public PartyStopFollowRequestMessage(uint partyId = 0)
		{
			PartyId = partyId;
		}

	}
}
