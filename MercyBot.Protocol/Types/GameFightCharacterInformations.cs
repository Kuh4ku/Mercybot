using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GameFightCharacterInformations : GameFightFighterNamedInformations
	{

		// Properties
		public uint Level { get; set; }
		public ActorAlignmentInformations AlignmentInfos { get; set; }
		public int Breed { get; set; }


		// Constructors
		public GameFightCharacterInformations() { }

		public GameFightCharacterInformations(int contextualId = 0, EntityLook look = null, EntityDispositionInformations disposition = null, uint teamId = 2, bool alive = false, GameFightMinimalStats stats = null, string name = "", PlayerStatus status = null, uint level = 0, ActorAlignmentInformations alignmentInfos = null, int breed = 0)
		{
			ContextualId = contextualId;
			Look = look;
			Disposition = disposition;
			TeamId = teamId;
			Alive = alive;
			Stats = stats;
			Name = name;
			Status = status;
			Level = level;
			AlignmentInfos = alignmentInfos;
			Breed = breed;
		}

	}
}
