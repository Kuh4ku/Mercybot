using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameContextActorInformations
	{

		// Properties
		public int ContextualId { get; set; }
		public EntityLook Look { get; set; }
		public EntityDispositionInformations Disposition { get; set; }


		// Constructors
		public GameContextActorInformations() { }

		public GameContextActorInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
		}

	}
}
