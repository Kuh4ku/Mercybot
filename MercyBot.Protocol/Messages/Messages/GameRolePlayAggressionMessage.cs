using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayAggressionMessage : Message
	{

		// Properties
		public uint AttackerId { get; set; }
		public uint DefenderId { get; set; }


		// Constructors
		public GameRolePlayAggressionMessage() { }

		public GameRolePlayAggressionMessage(uint attackerId = 0, uint defenderId = 0)
		{
			AttackerId = attackerId;
			DefenderId = defenderId;
		}

	}
}
