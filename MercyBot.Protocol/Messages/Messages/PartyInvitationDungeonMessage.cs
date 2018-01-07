using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyInvitationDungeonMessage : PartyInvitationMessage
	{

		// Properties
		public uint DungeonId { get; set; }


		// Constructors
		public PartyInvitationDungeonMessage() { }

		public PartyInvitationDungeonMessage(uint partyId = 0, uint partyType = 0, uint maxParticipants = 0, uint fromId = 0, string fromName = "", uint toId = 0, uint dungeonId = 0)
		{
			PartyId = partyId;
			PartyType = partyType;
			MaxParticipants = maxParticipants;
			FromId = fromId;
			FromName = fromName;
			ToId = toId;
			DungeonId = dungeonId;
		}

	}
}
