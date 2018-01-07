using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class StartupActionsObjetAttributionMessage : Message
	{

		// Properties
		public uint ActionId { get; set; }
		public uint CharacterId { get; set; }


		// Constructors
		public StartupActionsObjetAttributionMessage() { }

		public StartupActionsObjetAttributionMessage(uint actionId = 0, uint characterId = 0)
		{
			ActionId = actionId;
			CharacterId = characterId;
		}

	}
}
