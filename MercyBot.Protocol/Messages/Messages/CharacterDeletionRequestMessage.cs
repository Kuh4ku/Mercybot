using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterDeletionRequestMessage : Message
	{

		// Properties
		public uint CharacterId { get; set; }
		public string SecretAnswerHash { get; set; }


		// Constructors
		public CharacterDeletionRequestMessage() { }

		public CharacterDeletionRequestMessage(uint characterId = 0, string secretAnswerHash = "")
		{
			CharacterId = characterId;
			SecretAnswerHash = secretAnswerHash;
		}

	}
}
