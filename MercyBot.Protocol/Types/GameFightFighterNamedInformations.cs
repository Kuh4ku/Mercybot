using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameFightFighterNamedInformations : GameFightFighterInformations
	{

		// Properties
		public string Name { get; set; }
		public PlayerStatus Status { get; set; }


		// Constructors
		public GameFightFighterNamedInformations() { }

		public GameFightFighterNamedInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, uint teamId = 2, bool alive = false, GameFightMinimalStats stats = null, string name = "", PlayerStatus status = null)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			TeamId = teamId;
			Alive = alive;
			Stats = stats;
			Name = name;
			Status = status;
		}

	}
}
