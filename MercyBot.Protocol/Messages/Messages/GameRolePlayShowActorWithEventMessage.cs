using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayShowActorWithEventMessage : GameRolePlayShowActorMessage
	{

		// Properties
		public uint ActorEventId { get; set; }


		// Constructors
		public GameRolePlayShowActorWithEventMessage() { }

		public GameRolePlayShowActorWithEventMessage(GameRolePlayActorInformations informations = null, uint actorEventId = 0)
		{
			Informations = informations;
			ActorEventId = actorEventId;
		}

	}
}
