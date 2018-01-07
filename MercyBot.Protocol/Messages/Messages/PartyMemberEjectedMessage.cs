using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyMemberEjectedMessage : PartyMemberRemoveMessage
	{

		// Properties
		public uint KickerId { get; set; }


		// Constructors
		public PartyMemberEjectedMessage() { }

		public PartyMemberEjectedMessage(uint partyId = 0, uint leavingPlayerId = 0, uint kickerId = 0)
		{
			PartyId = partyId;
			LeavingPlayerId = leavingPlayerId;
			KickerId = kickerId;
		}

	}
}
