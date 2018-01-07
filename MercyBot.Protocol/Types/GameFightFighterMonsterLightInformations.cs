using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameFightFighterMonsterLightInformations : GameFightFighterLightInformations
	{

		// Properties
		public uint CreatureGenericId { get; set; }


		// Constructors
		public GameFightFighterMonsterLightInformations() { }

		public GameFightFighterMonsterLightInformations(int id = 0, uint level = 0, int breed = 0, bool sex = false, bool alive = false, uint creatureGenericId = 0)
		{
			Id = id;
			Level = level;
			Breed = breed;
			Sex = sex;
			Alive = alive;
			CreatureGenericId = creatureGenericId;
		}

	}
}
