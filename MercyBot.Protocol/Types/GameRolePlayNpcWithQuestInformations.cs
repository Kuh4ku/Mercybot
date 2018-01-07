using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameRolePlayNpcWithQuestInformations : GameRolePlayNpcInformations
	{

		// Properties
		public GameRolePlayNpcQuestFlag QuestFlag { get; set; }


		// Constructors
		public GameRolePlayNpcWithQuestInformations() { }

		public GameRolePlayNpcWithQuestInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, uint npcId = 0, bool sex = false, uint specialArtworkId = 0, GameRolePlayNpcQuestFlag questFlag = null)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			NpcId = npcId;
			Sex = sex;
			SpecialArtworkId = specialArtworkId;
			QuestFlag = questFlag;
		}

	}
}
