using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildFightPlayersHelpersLeaveMessage : Message
	{

		// Properties
		public double FightId { get; set; }
		public uint PlayerId { get; set; }


		// Constructors
		public GuildFightPlayersHelpersLeaveMessage() { }

		public GuildFightPlayersHelpersLeaveMessage(double fightId = 0, uint playerId = 0)
		{
			FightId = fightId;
			PlayerId = playerId;
		}

	}
}
