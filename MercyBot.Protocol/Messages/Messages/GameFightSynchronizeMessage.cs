using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightSynchronizeMessage : Message
	{

		// Properties
		public List<GameFightFighterInformations> Fighters { get; set; }


		// Constructors
		public GameFightSynchronizeMessage() { }

		public GameFightSynchronizeMessage(List<GameFightFighterInformations> fighters = null)
		{
			Fighters = fighters;
		}

	}
}
