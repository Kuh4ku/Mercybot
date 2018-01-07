using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayArenaUpdatePlayerInfosMessage : Message
	{

		// Properties
		public uint Rank { get; set; }
		public uint BestDailyRank { get; set; }
		public uint BestRank { get; set; }
		public uint VictoryCount { get; set; }
		public uint ArenaFightcount { get; set; }


		// Constructors
		public GameRolePlayArenaUpdatePlayerInfosMessage() { }

		public GameRolePlayArenaUpdatePlayerInfosMessage(uint rank = 0, uint bestDailyRank = 0, uint bestRank = 0, uint victoryCount = 0, uint arenaFightcount = 0)
		{
			Rank = rank;
			BestDailyRank = bestDailyRank;
			BestRank = bestRank;
			VictoryCount = victoryCount;
			ArenaFightcount = arenaFightcount;
		}

	}
}
