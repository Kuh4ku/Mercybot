using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameRolePlayNamedActorInformations : GameRolePlayActorInformations
	{

		// Properties
		public string Name { get; set; }


		// Constructors
		public GameRolePlayNamedActorInformations() { }

		public GameRolePlayNamedActorInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, string name = "")
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			Name = name;
		}

	}
}
