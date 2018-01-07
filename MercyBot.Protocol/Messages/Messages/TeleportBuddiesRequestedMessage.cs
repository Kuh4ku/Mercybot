using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TeleportBuddiesRequestedMessage : Message
	{

		// Properties
		public List<uint> InvalidBuddiesIds { get; set; }
		public uint DungeonId { get; set; }
		public uint InviterId { get; set; }


		// Constructors
		public TeleportBuddiesRequestedMessage() { }

		public TeleportBuddiesRequestedMessage(uint dungeonId = 0, uint inviterId = 0, List<uint> invalidBuddiesIds = null)
		{
			DungeonId = dungeonId;
			InviterId = inviterId;
			InvalidBuddiesIds = invalidBuddiesIds;
		}

	}
}
