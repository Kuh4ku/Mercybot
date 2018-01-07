using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class CharacterMinimalPlusLookAndGradeInformations : CharacterMinimalPlusLookInformations
	{

		// Properties
		public uint Grade { get; set; }


		// Constructors
		public CharacterMinimalPlusLookAndGradeInformations() { }

		public CharacterMinimalPlusLookAndGradeInformations(uint id = 0, uint level = 0, string name = "", EntityLook entityLook = null, uint grade = 0)
		{
			Id = id;
			Level = level;
			Name = name;
			EntityLook = entityLook;
			Grade = grade;
		}

	}
}
