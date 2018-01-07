using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyInvitationDungeonDetailsMessage : PartyInvitationDetailsMessage
	{

		// Properties
		public List<bool> PlayersDungeonReady { get; set; }
		public uint DungeonId { get; set; }


		// Constructors
		public PartyInvitationDungeonDetailsMessage() { }

		public PartyInvitationDungeonDetailsMessage(uint partyId = 0, uint partyType = 0, uint fromId = 0, string fromName = "", uint leaderId = 0, uint dungeonId = 0, List<PartyInvitationMemberInformations> members = null, List<PartyGuestInformations> guests = null, List<bool> playersDungeonReady = null)
		{
			PartyId = partyId;
			PartyType = partyType;
			FromId = fromId;
			FromName = fromName;
			LeaderId = leaderId;
			DungeonId = dungeonId;
			Members = members;
			Guests = guests;
			PlayersDungeonReady = playersDungeonReady;
		}

	}
}
