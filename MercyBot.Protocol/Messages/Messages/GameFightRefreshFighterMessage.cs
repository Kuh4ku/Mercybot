using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightRefreshFighterMessage : Message
	{

		// Properties
		public GameContextActorInformations Informations { get; set; }


		// Constructors
		public GameFightRefreshFighterMessage() { }

		public GameFightRefreshFighterMessage(GameContextActorInformations informations = null)
		{
			Informations = informations;
		}

	}
}
