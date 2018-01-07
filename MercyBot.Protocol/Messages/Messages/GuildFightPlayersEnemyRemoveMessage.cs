using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildFightPlayersEnemyRemoveMessage : Message
	{

		// Properties
		public double FightId { get; set; }
		public uint PlayerId { get; set; }


		// Constructors
		public GuildFightPlayersEnemyRemoveMessage() { }

		public GuildFightPlayersEnemyRemoveMessage(double fightId = 0, uint playerId = 0)
		{
			FightId = fightId;
			PlayerId = playerId;
		}

	}
}
