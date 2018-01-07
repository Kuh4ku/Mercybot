using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AbstractPartyEventMessage : AbstractPartyMessage
	{

		// Constructors
		public AbstractPartyEventMessage() { }

		public AbstractPartyEventMessage(uint partyId = 0)
		{
			PartyId = partyId;
		}

	}
}
