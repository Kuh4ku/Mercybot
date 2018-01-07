using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameFightTaxCollectorInformations : GameFightAIInformations
	{

		// Properties
		public uint FirstNameId { get; set; }
		public uint LastNameId { get; set; }
		public uint Level { get; set; }


		// Constructors
		public GameFightTaxCollectorInformations() { }

		public GameFightTaxCollectorInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, uint teamId = 2, bool alive = false, GameFightMinimalStats stats = null, uint firstNameId = 0, uint lastNameId = 0, uint level = 0)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			TeamId = teamId;
			Alive = alive;
			Stats = stats;
			FirstNameId = firstNameId;
			LastNameId = lastNameId;
			Level = level;
		}

	}
}
