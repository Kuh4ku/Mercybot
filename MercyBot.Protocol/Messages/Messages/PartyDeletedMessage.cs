using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyDeletedMessage : AbstractPartyMessage
	{

		// Constructors
		public PartyDeletedMessage() { }

		public PartyDeletedMessage(uint partyId = 0)
		{
			PartyId = partyId;
		}

	}
}
