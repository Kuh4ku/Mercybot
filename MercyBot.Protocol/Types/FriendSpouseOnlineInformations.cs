using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FriendSpouseOnlineInformations : FriendSpouseInformations
	{

		// Properties
		public uint MapId { get; set; }
		public uint SubAreaId { get; set; }
		public bool InFight { get; set; }
		public bool FollowSpouse { get; set; }


		// Constructors
		public FriendSpouseOnlineInformations() { }

		public FriendSpouseOnlineInformations(uint spouseAccountId = 0, uint spouseId = 0, string spouseName = "", uint spouseLevel = 0, int breed = 0, int sex = 0, EntityLook spouseEntityLook = null, BasicGuildInformations guildInfo = null, int alignmentSide = 0, uint mapId = 0, uint subAreaId = 0, bool inFight = false, bool followSpouse = false)
		{
			SpouseAccountId = spouseAccountId;
			SpouseId = spouseId;
			SpouseName = spouseName;
			SpouseLevel = spouseLevel;
			Breed = breed;
			Sex = sex;
			SpouseEntityLook = spouseEntityLook;
			GuildInfo = guildInfo;
			AlignmentSide = alignmentSide;
			MapId = mapId;
			SubAreaId = subAreaId;
			InFight = inFight;
			FollowSpouse = followSpouse;
		}

	}
}
