using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameFightMutantInformations : GameFightFighterNamedInformations
	{

		// Properties
		public uint PowerLevel { get; set; }


		// Constructors
		public GameFightMutantInformations() { }

		public GameFightMutantInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, uint teamId = 2, bool alive = false, GameFightMinimalStats stats = null, string name = "", PlayerStatus status = null, uint powerLevel = 0)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			TeamId = teamId;
			Alive = alive;
			Stats = stats;
			Name = name;
			Status = status;
			PowerLevel = powerLevel;
		}

	}
}
