using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class DungeonPartyFinderRoomContentUpdateMessage : Message
	{

		// Properties
		public List<DungeonPartyFinderPlayer> AddedPlayers { get; set; }
		public List<uint> RemovedPlayersIds { get; set; }
		public uint DungeonId { get; set; }


		// Constructors
		public DungeonPartyFinderRoomContentUpdateMessage() { }

		public DungeonPartyFinderRoomContentUpdateMessage(uint dungeonId = 0, List<DungeonPartyFinderPlayer> addedPlayers = null, List<uint> removedPlayersIds = null)
		{
			DungeonId = dungeonId;
			AddedPlayers = addedPlayers;
			RemovedPlayersIds = removedPlayersIds;
		}

	}
}
