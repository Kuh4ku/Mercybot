using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildFightPlayersEnemiesListMessage : Message
	{

		// Properties
		public List<CharacterMinimalPlusLookInformations> PlayerInfo { get; set; }
		public double FightId { get; set; }


		// Constructors
		public GuildFightPlayersEnemiesListMessage() { }

		public GuildFightPlayersEnemiesListMessage(double fightId = 0, List<CharacterMinimalPlusLookInformations> playerInfo = null)
		{
			FightId = fightId;
			PlayerInfo = playerInfo;
		}

	}
}
