using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameFightFighterLightInformations
	{

		// Properties
		public int Id { get; set; }
		public uint Level { get; set; }
		public int Breed { get; set; }
		public bool Sex { get; set; }
		public bool Alive { get; set; }


		// Constructors
		public GameFightFighterLightInformations() { }

		public GameFightFighterLightInformations(int id = 0, uint level = 0, int breed = 0, bool sex = false, bool alive = false)
		{
			Id = id;
			Level = level;
			Breed = breed;
			Sex = sex;
			Alive = alive;
		}

	}
}
