using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class DungeonPartyFinderRegisterSuccessMessage : Message
	{

		// Properties
		public List<uint> DungeonIds { get; set; }


		// Constructors
		public DungeonPartyFinderRegisterSuccessMessage() { }

		public DungeonPartyFinderRegisterSuccessMessage(List<uint> dungeonIds = null)
		{
			DungeonIds = dungeonIds;
		}

	}
}
