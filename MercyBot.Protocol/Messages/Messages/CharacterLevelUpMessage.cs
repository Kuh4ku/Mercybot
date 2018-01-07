using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterLevelUpMessage : Message
	{

		// Properties
		public uint NewLevel { get; set; }


		// Constructors
		public CharacterLevelUpMessage() { }

		public CharacterLevelUpMessage(uint newLevel = 0)
		{
			NewLevel = newLevel;
		}

	}
}
