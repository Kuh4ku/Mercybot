using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectUseOnCharacterMessage : ObjectUseMessage
	{

		// Properties
		public uint CharacterId { get; set; }


		// Constructors
		public ObjectUseOnCharacterMessage() { }

		public ObjectUseOnCharacterMessage(uint objectUID = 0, uint characterId = 0)
		{
			ObjectUID = objectUID;
			CharacterId = characterId;
		}

	}
}
