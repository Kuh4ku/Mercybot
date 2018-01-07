using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyLeaderUpdateMessage : AbstractPartyEventMessage
	{

		// Properties
		public uint PartyLeaderId { get; set; }


		// Constructors
		public PartyLeaderUpdateMessage() { }

		public PartyLeaderUpdateMessage(uint partyId = 0, uint partyLeaderId = 0)
		{
			PartyId = partyId;
			PartyLeaderId = partyLeaderId;
		}

	}
}
