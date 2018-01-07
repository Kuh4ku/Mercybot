using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameFightFighterCompanionLightInformations : GameFightFighterLightInformations
	{

		// Properties
		public int CompanionId { get; set; }
		public int MasterId { get; set; }


		// Constructors
		public GameFightFighterCompanionLightInformations() { }

		public GameFightFighterCompanionLightInformations(int id = 0, uint level = 0, int breed = 0, bool sex = false, bool alive = false, int companionId = 0, int masterId = 0)
		{
			Id = id;
			Level = level;
			Breed = breed;
			Sex = sex;
			Alive = alive;
			CompanionId = companionId;
			MasterId = masterId;
		}

	}
}
