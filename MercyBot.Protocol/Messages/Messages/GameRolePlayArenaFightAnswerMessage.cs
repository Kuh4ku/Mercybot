using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayArenaFightAnswerMessage : Message
	{

		// Properties
		public int FightId { get; set; }
		public bool Accept { get; set; }


		// Constructors
		public GameRolePlayArenaFightAnswerMessage() { }

		public GameRolePlayArenaFightAnswerMessage(int fightId = 0, bool accept = false)
		{
			FightId = fightId;
			Accept = accept;
		}

	}
}
