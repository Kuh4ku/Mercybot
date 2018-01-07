using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TeleportToBuddyCloseMessage : Message
	{

		// Properties
		public uint DungeonId { get; set; }
		public uint BuddyId { get; set; }


		// Constructors
		public TeleportToBuddyCloseMessage() { }

		public TeleportToBuddyCloseMessage(uint dungeonId = 0, uint buddyId = 0)
		{
			DungeonId = dungeonId;
			BuddyId = buddyId;
		}

	}
}
