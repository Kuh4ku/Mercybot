using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameFightCompanionInformations : GameFightFighterInformations
	{

		// Properties
		public uint CompanionGenericId { get; set; }
		public uint Level { get; set; }
		public int MasterId { get; set; }


		// Constructors
		public GameFightCompanionInformations() { }

		public GameFightCompanionInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, uint teamId = 2, bool alive = false, GameFightMinimalStats stats = null, uint companionGenericId = 0, uint level = 0, int masterId = 0)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			TeamId = teamId;
			Alive = alive;
			Stats = stats;
			CompanionGenericId = companionGenericId;
			Level = level;
			MasterId = masterId;
		}

	}
}
