using System.Collections.Generic;
using MercyBot.Protocol.Types;
using Newtonsoft.Json;
using MercyBot.Protocol.Converters;

namespace MercyBot.Protocol.Messages
{
	public class GameRolePlayShowActorMessage : Message
	{

		// Properties
        [JsonConverter(typeof(TypedPropertyConverter))]
		public GameRolePlayActorInformations Informations { get; set; }


		// Constructors
		public GameRolePlayShowActorMessage() { }

		public GameRolePlayShowActorMessage(GameRolePlayActorInformations informations = null)
		{
			Informations = informations;
		}

	}
}
