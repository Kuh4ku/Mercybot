using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class CharacterMinimalGuildInformations : CharacterMinimalPlusLookInformations
	{

		// Properties
		public BasicGuildInformations Guild { get; set; }


		// Constructors
		public CharacterMinimalGuildInformations() { }

		public CharacterMinimalGuildInformations(uint id = 0, uint level = 0, string name = "", EntityLook entityLook = null, BasicGuildInformations guild = null)
		{
			Id = id;
			Level = level;
			Name = name;
			EntityLook = entityLook;
			Guild = guild;
		}

	}
}
