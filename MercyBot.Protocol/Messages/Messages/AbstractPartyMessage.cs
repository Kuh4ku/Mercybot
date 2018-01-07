using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AbstractPartyMessage : Message
	{

		// Properties
		public uint PartyId { get; set; }


		// Constructors
		public AbstractPartyMessage() { }

		public AbstractPartyMessage(uint partyId = 0)
		{
			PartyId = partyId;
		}

	}
}
