using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PartyMemberArenaInformations : PartyMemberInformations
	{

		// Properties
		public uint Rank { get; set; }


		// Constructors
		public PartyMemberArenaInformations() { }

		public PartyMemberArenaInformations(uint id = 0, uint level = 0, string name = "", EntityLook entityLook = null, int breed = 0, bool sex = false, uint lifePoints = 0, uint maxLifePoints = 0, uint prospecting = 0, uint regenRate = 0, uint initiative = 0, int alignmentSide = 0, int worldX = 0, int worldY = 0, int mapId = 0, uint subAreaId = 0, PlayerStatus status = null, uint rank = 0, List<PartyCompanionMemberInformations> companions = null)
		{
			Id = id;
			Level = level;
			Name = name;
			EntityLook = entityLook;
			Breed = breed;
			Sex = sex;
			LifePoints = lifePoints;
			MaxLifePoints = maxLifePoints;
			Prospecting = prospecting;
			RegenRate = regenRate;
			Initiative = initiative;
			AlignmentSide = alignmentSide;
			WorldX = worldX;
			WorldY = worldY;
			MapId = mapId;
			SubAreaId = subAreaId;
			Status = status;
			Rank = rank;
			Companions = companions;
		}

	}
}
