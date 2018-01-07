using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightJoinRequestMessage : Message
	{

		// Properties
		public uint FighterId { get; set; }
		public uint FightId { get; set; }


		// Constructors
		public GameFightJoinRequestMessage() { }

		public GameFightJoinRequestMessage(uint fighterId = 0, uint fightId = 0)
		{
			FighterId = fighterId;
			FightId = fightId;
		}

	}
}
