using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class MonsterInGroupInformations : MonsterInGroupLightInformations
	{

		// Properties
		public EntityLook Look { get; set; }


		// Constructors
		public MonsterInGroupInformations() { }

		public MonsterInGroupInformations(int creatureGenericId = 0, uint grade = 0, EntityLook look = null)
		{
			CreatureGenericId = creatureGenericId;
			Grade = grade;
			Look = look;
		}

	}
}
