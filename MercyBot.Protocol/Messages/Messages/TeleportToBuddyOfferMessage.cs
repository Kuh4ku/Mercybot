using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TeleportToBuddyOfferMessage : Message
	{

		// Properties
		public uint DungeonId { get; set; }
		public uint BuddyId { get; set; }
		public uint TimeLeft { get; set; }


		// Constructors
		public TeleportToBuddyOfferMessage() { }

		public TeleportToBuddyOfferMessage(uint dungeonId = 0, uint buddyId = 0, uint timeLeft = 0)
		{
			DungeonId = dungeonId;
			BuddyId = buddyId;
			TimeLeft = timeLeft;
		}

	}
}
