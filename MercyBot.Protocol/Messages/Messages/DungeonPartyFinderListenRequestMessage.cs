using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class DungeonPartyFinderListenRequestMessage : Message
	{

		// Properties
		public uint DungeonId { get; set; }


		// Constructors
		public DungeonPartyFinderListenRequestMessage() { }

		public DungeonPartyFinderListenRequestMessage(uint dungeonId = 0)
		{
			DungeonId = dungeonId;
		}

	}
}
