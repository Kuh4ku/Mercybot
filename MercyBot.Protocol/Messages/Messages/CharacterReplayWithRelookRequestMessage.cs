using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterReplayWithRelookRequestMessage : CharacterReplayRequestMessage
	{

		// Properties
		public uint CosmeticId { get; set; }


		// Constructors
		public CharacterReplayWithRelookRequestMessage() { }

		public CharacterReplayWithRelookRequestMessage(uint characterId = 0, uint cosmeticId = 0)
		{
			CharacterId = characterId;
			CosmeticId = cosmeticId;
		}

	}
}
