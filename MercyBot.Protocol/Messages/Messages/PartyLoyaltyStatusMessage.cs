using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyLoyaltyStatusMessage : AbstractPartyMessage
	{

		// Properties
		public bool Loyal { get; set; }


		// Constructors
		public PartyLoyaltyStatusMessage() { }

		public PartyLoyaltyStatusMessage(uint partyId = 0, bool loyal = false)
		{
			PartyId = partyId;
			Loyal = loyal;
		}

	}
}
