using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterReplayRequestMessage : Message
	{

		// Properties
		public uint CharacterId { get; set; }


		// Constructors
		public CharacterReplayRequestMessage() { }

		public CharacterReplayRequestMessage(uint characterId = 0)
		{
			CharacterId = characterId;
		}

	}
}
