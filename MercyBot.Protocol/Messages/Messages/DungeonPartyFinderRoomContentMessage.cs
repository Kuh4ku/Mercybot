using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class DungeonPartyFinderRoomContentMessage : Message
	{

		// Properties
		public List<DungeonPartyFinderPlayer> Players { get; set; }
		public uint DungeonId { get; set; }


		// Constructors
		public DungeonPartyFinderRoomContentMessage() { }

		public DungeonPartyFinderRoomContentMessage(uint dungeonId = 0, List<DungeonPartyFinderPlayer> players = null)
		{
			DungeonId = dungeonId;
			Players = players;
		}

	}
}
