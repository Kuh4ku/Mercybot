using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class CharacterBaseInformations : CharacterMinimalPlusLookInformations
	{

		// Properties
		public int Breed { get; set; }
		public bool Sex { get; set; }


		// Constructors
		public CharacterBaseInformations() { }

		public CharacterBaseInformations(uint id = 0, uint level = 0, string name = "", EntityLook entityLook = null, int breed = 0, bool sex = false)
		{
			Id = id;
			Level = level;
			Name = name;
			EntityLook = entityLook;
			Breed = breed;
			Sex = sex;
		}

	}
}
