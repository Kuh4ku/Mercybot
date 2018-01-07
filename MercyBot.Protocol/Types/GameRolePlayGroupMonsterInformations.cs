using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameRolePlayGroupMonsterInformations : GameRolePlayActorInformations
	{

		// Properties
		public GroupMonsterStaticInformations StaticInfos { get; set; }
		public int AgeBonus { get; set; }
		public int LootShare { get; set; }
		public int AlignmentSide { get; set; }
		public bool KeyRingBonus { get; set; }
		public bool HasHardcoreDrop { get; set; }
		public bool HasAVARewardToken { get; set; }


		// Constructors
		public GameRolePlayGroupMonsterInformations() { }

		public GameRolePlayGroupMonsterInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, GroupMonsterStaticInformations staticInfos = null, int ageBonus = 0, int lootShare = 0, int alignmentSide = 0, bool keyRingBonus = false, bool hasHardcoreDrop = false, bool hasAVARewardToken = false)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			StaticInfos = staticInfos;
			AgeBonus = ageBonus;
			LootShare = lootShare;
			AlignmentSide = alignmentSide;
			KeyRingBonus = keyRingBonus;
			HasHardcoreDrop = hasHardcoreDrop;
			HasAVARewardToken = hasAVARewardToken;
		}

	}
}
