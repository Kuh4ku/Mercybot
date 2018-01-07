using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterReplayWithRenameRequestMessage : CharacterReplayRequestMessage
	{

		// Properties
		public string Name { get; set; }


		// Constructors
		public CharacterReplayWithRenameRequestMessage() { }

		public CharacterReplayWithRenameRequestMessage(uint characterId = 0, string name = "")
		{
			CharacterId = characterId;
			Name = name;
		}

	}
}
