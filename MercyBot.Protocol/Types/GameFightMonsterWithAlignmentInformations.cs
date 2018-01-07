using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameFightMonsterWithAlignmentInformations : GameFightMonsterInformations
	{

		// Properties
		public ActorAlignmentInformations AlignmentInfos { get; set; }


		// Constructors
		public GameFightMonsterWithAlignmentInformations() { }

		public GameFightMonsterWithAlignmentInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, uint teamId = 2, bool alive = false, GameFightMinimalStats stats = null, uint creatureGenericId = 0, uint creatureGrade = 0, ActorAlignmentInformations alignmentInfos = null)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			TeamId = teamId;
			Alive = alive;
			Stats = stats;
			CreatureGenericId = creatureGenericId;
			CreatureGrade = creatureGrade;
			AlignmentInfos = alignmentInfos;
		}

	}
}
