using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class CharacterHardcoreInformations : CharacterBaseInformations
	{

		// Properties
		public uint DeathState { get; set; }
		public uint DeathCount { get; set; }
		public uint DeathMaxLevel { get; set; }


		// Constructors
		public CharacterHardcoreInformations() { }

		public CharacterHardcoreInformations(uint id = 0, uint level = 0, string name = "", EntityLook entityLook = null, int breed = 0, bool sex = false, uint deathState = 0, uint deathCount = 0, uint deathMaxLevel = 0)
		{
			Id = id;
			Level = level;
			Name = name;
			EntityLook = entityLook;
			Breed = breed;
			Sex = sex;
			DeathState = deathState;
			DeathCount = deathCount;
			DeathMaxLevel = deathMaxLevel;
		}

	}
}
