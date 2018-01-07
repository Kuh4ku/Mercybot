using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameRolePlayCharacterInformations : GameRolePlayHumanoidInformations
	{

		// Properties
		public ActorAlignmentInformations AlignmentInfos { get; set; }


		// Constructors
		public GameRolePlayCharacterInformations() { }

		public GameRolePlayCharacterInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, string name = "", HumanInformations humanoidInfo = null, uint accountId = 0, ActorAlignmentInformations alignmentInfos = null)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			Name = name;
			HumanoidInfo = humanoidInfo;
			AccountId = accountId;
			AlignmentInfos = alignmentInfos;
		}

	}
}
