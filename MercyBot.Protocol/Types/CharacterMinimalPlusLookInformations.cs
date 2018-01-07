using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class CharacterMinimalPlusLookInformations : CharacterMinimalInformations
	{

		// Properties
		public EntityLook EntityLook { get; set; }


		// Constructors
		public CharacterMinimalPlusLookInformations() { }

		public CharacterMinimalPlusLookInformations(uint id = 0, uint level = 0, string name = "", EntityLook entityLook = null)
		{
			Id = id;
			Level = level;
			Name = name;
			EntityLook = entityLook;
		}

	}
}
