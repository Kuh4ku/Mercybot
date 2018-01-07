using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class CharacterMinimalInformations : AbstractCharacterInformation
	{

		// Properties
		public uint Level { get; set; }
		public string Name { get; set; }


		// Constructors
		public CharacterMinimalInformations() { }

		public CharacterMinimalInformations(uint id = 0, uint level = 0, string name = "")
		{
			Id = id;
			Level = level;
			Name = name;
		}

	}
}
