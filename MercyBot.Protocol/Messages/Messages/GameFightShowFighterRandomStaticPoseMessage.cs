using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightShowFighterRandomStaticPoseMessage : GameFightShowFighterMessage
	{

		// Constructors
		public GameFightShowFighterRandomStaticPoseMessage() { }

		public GameFightShowFighterRandomStaticPoseMessage(GameFightFighterInformations informations = null)
		{
			Informations = informations;
		}

	}
}
