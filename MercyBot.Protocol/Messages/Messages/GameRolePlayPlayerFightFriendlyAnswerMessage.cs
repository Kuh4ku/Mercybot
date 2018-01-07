using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayPlayerFightFriendlyAnswerMessage : Message
	{

		// Properties
		public int FightId { get; set; }
		public bool Accept { get; set; }


		// Constructors
		public GameRolePlayPlayerFightFriendlyAnswerMessage() { }

		public GameRolePlayPlayerFightFriendlyAnswerMessage(int fightId = 0, bool accept = false)
		{
			FightId = fightId;
			Accept = accept;
		}

	}
}
