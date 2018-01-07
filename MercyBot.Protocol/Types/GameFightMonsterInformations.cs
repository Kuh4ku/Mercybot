using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameFightMonsterInformations : GameFightAIInformations
	{

		// Properties
		public uint CreatureGenericId { get; set; }
		public uint CreatureGrade { get; set; }


		// Constructors
		public GameFightMonsterInformations() { }

		public GameFightMonsterInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, uint teamId = 2, bool alive = false, GameFightMinimalStats stats = null, uint creatureGenericId = 0, uint creatureGrade = 0)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			TeamId = teamId;
			Alive = alive;
			Stats = stats;
			CreatureGenericId = creatureGenericId;
			CreatureGrade = creatureGrade;
		}

	}
}
