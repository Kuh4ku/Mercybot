using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyModifiableStatusMessage : AbstractPartyMessage
	{

		// Properties
		public bool Enabled { get; set; }


		// Constructors
		public PartyModifiableStatusMessage() { }

		public PartyModifiableStatusMessage(uint partyId = 0, bool enabled = false)
		{
			PartyId = partyId;
			Enabled = enabled;
		}

	}
}
