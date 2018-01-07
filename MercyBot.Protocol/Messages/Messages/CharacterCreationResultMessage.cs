using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterCreationResultMessage : Message
	{

		// Properties
		public uint Result { get; set; }


		// Constructors
		public CharacterCreationResultMessage() { }

		public CharacterCreationResultMessage(uint result = 1)
		{
			Result = result;
		}

	}
}
