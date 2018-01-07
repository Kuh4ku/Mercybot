using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TeleportBuddiesMessage : Message
	{

		// Properties
		public uint DungeonId { get; set; }


		// Constructors
		public TeleportBuddiesMessage() { }

		public TeleportBuddiesMessage(uint dungeonId = 0)
		{
			DungeonId = dungeonId;
		}

	}
}
