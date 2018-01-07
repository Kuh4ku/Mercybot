using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyInvitationDungeonRequestMessage : PartyInvitationRequestMessage
	{

		// Properties
		public uint DungeonId { get; set; }


		// Constructors
		public PartyInvitationDungeonRequestMessage() { }

		public PartyInvitationDungeonRequestMessage(string name = "", uint dungeonId = 0)
		{
			Name = name;
			DungeonId = dungeonId;
		}

	}
}
