using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameRolePlayMutantInformations : GameRolePlayHumanoidInformations
	{

		// Properties
		public int MonsterId { get; set; }
		public int PowerLevel { get; set; }


		// Constructors
		public GameRolePlayMutantInformations() { }

		public GameRolePlayMutantInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, string name = "", HumanInformations humanoidInfo = null, uint accountId = 0, int monsterId = 0, int powerLevel = 0)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			Name = name;
			HumanoidInfo = humanoidInfo;
			AccountId = accountId;
			MonsterId = monsterId;
			PowerLevel = powerLevel;
		}

	}
}
