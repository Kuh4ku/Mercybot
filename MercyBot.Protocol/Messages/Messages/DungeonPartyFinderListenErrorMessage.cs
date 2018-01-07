using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class DungeonPartyFinderListenErrorMessage : Message
	{

		// Properties
		public uint DungeonId { get; set; }


		// Constructors
		public DungeonPartyFinderListenErrorMessage() { }

		public DungeonPartyFinderListenErrorMessage(uint dungeonId = 0)
		{
			DungeonId = dungeonId;
		}

	}
}
