using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TeleportToBuddyAnswerMessage : Message
	{

		// Properties
		public uint DungeonId { get; set; }
		public uint BuddyId { get; set; }
		public bool Accept { get; set; }


		// Constructors
		public TeleportToBuddyAnswerMessage() { }

		public TeleportToBuddyAnswerMessage(uint dungeonId = 0, uint buddyId = 0, bool accept = false)
		{
			DungeonId = dungeonId;
			BuddyId = buddyId;
			Accept = accept;
		}

	}
}
