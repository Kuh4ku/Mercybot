using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildFightPlayersHelpersJoinMessage : Message
	{

		// Properties
		public double FightId { get; set; }
		public CharacterMinimalPlusLookInformations PlayerInfo { get; set; }


		// Constructors
		public GuildFightPlayersHelpersJoinMessage() { }

		public GuildFightPlayersHelpersJoinMessage(double fightId = 0, CharacterMinimalPlusLookInformations playerInfo = null)
		{
			FightId = fightId;
			PlayerInfo = playerInfo;
		}

	}
}
