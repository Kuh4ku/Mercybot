using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyAbdicateThroneMessage : AbstractPartyMessage
	{

		// Properties
		public uint PlayerId { get; set; }


		// Constructors
		public PartyAbdicateThroneMessage() { }

		public PartyAbdicateThroneMessage(uint partyId = 0, uint playerId = 0)
		{
			PartyId = partyId;
			PlayerId = playerId;
		}

	}
}
