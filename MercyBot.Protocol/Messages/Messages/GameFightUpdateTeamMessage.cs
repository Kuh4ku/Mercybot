using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightUpdateTeamMessage : Message
	{

		// Properties
		public uint FightId { get; set; }
		public FightTeamInformations Team { get; set; }


		// Constructors
		public GameFightUpdateTeamMessage() { }

		public GameFightUpdateTeamMessage(uint fightId = 0, FightTeamInformations team = null)
		{
			FightId = fightId;
			Team = team;
		}

	}
}
