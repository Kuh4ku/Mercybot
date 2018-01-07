using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameFightFighterTaxCollectorLightInformations : GameFightFighterLightInformations
	{

		// Properties
		public uint FirstNameId { get; set; }
		public uint LastNameId { get; set; }


		// Constructors
		public GameFightFighterTaxCollectorLightInformations() { }

		public GameFightFighterTaxCollectorLightInformations(int id = 0, uint level = 0, int breed = 0, bool sex = false, bool alive = false, uint firstNameId = 0, uint lastNameId = 0)
		{
			Id = id;
			Level = level;
			Breed = breed;
			Sex = sex;
			Alive = alive;
			FirstNameId = firstNameId;
			LastNameId = lastNameId;
		}

	}
}
