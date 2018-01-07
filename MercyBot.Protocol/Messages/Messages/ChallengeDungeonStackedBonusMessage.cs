using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChallengeDungeonStackedBonusMessage : Message
	{

		// Properties
		public uint DungeonId { get; set; }
		public uint XpBonus { get; set; }
		public uint DropBonus { get; set; }


		// Constructors
		public ChallengeDungeonStackedBonusMessage() { }

		public ChallengeDungeonStackedBonusMessage(uint dungeonId = 0, uint xpBonus = 0, uint dropBonus = 0)
		{
			DungeonId = dungeonId;
			XpBonus = xpBonus;
			DropBonus = dropBonus;
		}

	}
}
