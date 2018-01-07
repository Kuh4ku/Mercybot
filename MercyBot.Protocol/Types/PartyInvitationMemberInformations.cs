using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PartyInvitationMemberInformations : CharacterBaseInformations
	{

		// Properties
		public List<PartyCompanionBaseInformations> Companions { get; set; }
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public int MapId { get; set; }
		public uint SubAreaId { get; set; }


		// Constructors
		public PartyInvitationMemberInformations() { }

		public PartyInvitationMemberInformations(uint id = 0, uint level = 0, string name = "", EntityLook entityLook = null, int breed = 0, bool sex = false, int worldX = 0, int worldY = 0, int mapId = 0, uint subAreaId = 0, List<PartyCompanionBaseInformations> companions = null)
		{
			Id = id;
			Level = level;
			Name = name;
			EntityLook = entityLook;
			Breed = breed;
			Sex = sex;
			WorldX = worldX;
			WorldY = worldY;
			MapId = mapId;
			SubAreaId = subAreaId;
			Companions = companions;
		}

	}
}
