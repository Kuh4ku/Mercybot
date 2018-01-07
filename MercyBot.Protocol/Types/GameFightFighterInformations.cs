using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameFightFighterInformations : GameContextActorInformations
	{

		// Properties
		public uint TeamId { get; set; }
		public bool Alive { get; set; }
		public GameFightMinimalStats Stats { get; set; }


		// Constructors
		public GameFightFighterInformations() { }

		public GameFightFighterInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, uint teamId = 2, bool alive = false, GameFightMinimalStats stats = null)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			TeamId = teamId;
			Alive = alive;
			Stats = stats;
		}

	}
}
