using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ObjectEffectCreature : ObjectEffect
	{

		// Properties
		public uint MonsterFamilyId { get; set; }


		// Constructors
		public ObjectEffectCreature() { }

		public ObjectEffectCreature(uint actionId = 0, uint monsterFamilyId = 0)
		{
			ActionId = actionId;
			MonsterFamilyId = monsterFamilyId;
		}

	}
}
