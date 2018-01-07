using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GameFightHumanReadyStateMessage : Message
	{

		// Properties
		public uint CharacterId { get; set; }
		public bool IsReady { get; set; }


		// Constructors
		public GameFightHumanReadyStateMessage() { }

		public GameFightHumanReadyStateMessage(uint characterId = 0, bool isReady = false)
		{
			CharacterId = characterId;
			IsReady = isReady;
		}

	}
}
