using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameRolePlayPrismInformations : GameRolePlayActorInformations
	{

		// Properties
		public PrismInformation Prism { get; set; }


		// Constructors
		public GameRolePlayPrismInformations() { }

		public GameRolePlayPrismInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, PrismInformation prism = null)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			Prism = prism;
		}

	}
}
