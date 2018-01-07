using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyLeaveMessage : AbstractPartyMessage
	{

		// Constructors
		public PartyLeaveMessage() { }

		public PartyLeaveMessage(uint partyId = 0)
		{
			PartyId = partyId;
		}

	}
}
