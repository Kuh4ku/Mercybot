using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class DungeonLeftMessage : Message
	{

		// Properties
		public uint DungeonId { get; set; }


		// Constructors
		public DungeonLeftMessage() { }

		public DungeonLeftMessage(uint dungeonId = 0)
		{
			DungeonId = dungeonId;
		}

	}
}
