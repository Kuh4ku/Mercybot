using System.Collections.Generic;
using MercyBot.Protocol.Types;
using Newtonsoft.Json;
using MercyBot.Protocol.Converters;

namespace MercyBot.Protocol.Messages
{
	public class GameFightShowFighterMessage : Message
	{

		// Properties
        [JsonConverter(typeof(TypedPropertyConverter))]
		public GameFightFighterInformations Informations { get; set; }


		// Constructors
		public GameFightShowFighterMessage() { }

		public GameFightShowFighterMessage(GameFightFighterInformations informations = null)
		{
			Informations = informations;
		}

	}
}
