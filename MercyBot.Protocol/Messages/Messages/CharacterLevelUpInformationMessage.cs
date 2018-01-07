using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CharacterLevelUpInformationMessage : CharacterLevelUpMessage
	{

		// Properties
		public string Name { get; set; }
		public uint Id { get; set; }


		// Constructors
		public CharacterLevelUpInformationMessage() { }

		public CharacterLevelUpInformationMessage(uint newLevel = 0, string name = "", uint id = 0)
		{
			NewLevel = newLevel;
			Name = name;
			Id = id;
		}

	}
}
