using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class DungeonPartyFinderRegisterRequestMessage : Message
	{

		// Properties
		public List<uint> DungeonIds { get; set; }


		// Constructors
		public DungeonPartyFinderRegisterRequestMessage() { }

		public DungeonPartyFinderRegisterRequestMessage(List<uint> dungeonIds = null)
		{
			DungeonIds = dungeonIds;
		}

	}
}
