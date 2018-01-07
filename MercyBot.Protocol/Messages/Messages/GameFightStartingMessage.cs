using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightStartingMessage : Message
	{

		// Properties
		public uint FightType { get; set; }


		// Constructors
		public GameFightStartingMessage() { }

		public GameFightStartingMessage(uint fightType = 0)
		{
			FightType = fightType;
		}

	}
}
