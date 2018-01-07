using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations
	{

		// Properties
		public HumanInformations HumanoidInfo { get; set; }
		public uint AccountId { get; set; }


		// Constructors
		public GameRolePlayHumanoidInformations() { }

		public GameRolePlayHumanoidInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, string name = "", HumanInformations humanoidInfo = null, uint accountId = 0)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			Name = name;
			HumanoidInfo = humanoidInfo;
			AccountId = accountId;
		}

	}
}
