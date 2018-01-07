using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameRolePlayActorInformations : GameContextActorInformations
	{

		// Constructors
		public GameRolePlayActorInformations() { }

		public GameRolePlayActorInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
		}

	}
}
