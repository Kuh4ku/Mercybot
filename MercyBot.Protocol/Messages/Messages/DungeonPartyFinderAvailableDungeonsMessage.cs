using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class DungeonPartyFinderAvailableDungeonsMessage : Message
	{

		// Properties
		public List<uint> DungeonIds { get; set; }


		// Constructors
		public DungeonPartyFinderAvailableDungeonsMessage() { }

		public DungeonPartyFinderAvailableDungeonsMessage(List<uint> dungeonIds = null)
		{
			DungeonIds = dungeonIds;
		}

	}
}
