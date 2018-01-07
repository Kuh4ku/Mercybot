using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameFightFighterNamedLightInformations : GameFightFighterLightInformations
	{

		// Properties
		public string Name { get; set; }


		// Constructors
		public GameFightFighterNamedLightInformations() { }

		public GameFightFighterNamedLightInformations(int id = 0, uint level = 0, int breed = 0, bool sex = false, bool alive = false, string name = "")
		{
			Id = id;
			Level = level;
			Breed = breed;
			Sex = sex;
			Alive = alive;
			Name = name;
		}

	}
}
