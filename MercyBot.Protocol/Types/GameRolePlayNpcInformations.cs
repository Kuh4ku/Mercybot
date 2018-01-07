using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameRolePlayNpcInformations : GameRolePlayActorInformations
	{

		// Properties
		public uint NpcId { get; set; }
		public bool Sex { get; set; }
		public uint SpecialArtworkId { get; set; }


		// Constructors
		public GameRolePlayNpcInformations() { }

		public GameRolePlayNpcInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, uint npcId = 0, bool sex = false, uint specialArtworkId = 0)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			NpcId = npcId;
			Sex = sex;
			SpecialArtworkId = specialArtworkId;
		}

	}
}
