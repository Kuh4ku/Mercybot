using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightRemoveTeamMemberMessage : Message
	{

		// Properties
		public uint FightId { get; set; }
		public uint TeamId { get; set; }
		public int CharId { get; set; }


		// Constructors
		public GameFightRemoveTeamMemberMessage() { }

		public GameFightRemoveTeamMemberMessage(uint fightId = 0, uint teamId = 2, int charId = 0)
		{
			FightId = fightId;
			TeamId = teamId;
			CharId = charId;
		}

	}
}
