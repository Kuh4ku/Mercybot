using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FriendSpouseInformations
	{

		// Properties
		public uint SpouseAccountId { get; set; }
		public uint SpouseId { get; set; }
		public string SpouseName { get; set; }
		public uint SpouseLevel { get; set; }
		public int Breed { get; set; }
		public int Sex { get; set; }
		public EntityLook SpouseEntityLook { get; set; }
		public BasicGuildInformations GuildInfo { get; set; }
		public int AlignmentSide { get; set; }


		// Constructors
		public FriendSpouseInformations() { }

		public FriendSpouseInformations(uint spouseAccountId = 0, uint spouseId = 0, string spouseName = "", uint spouseLevel = 0, int breed = 0, int sex = 0, EntityLook spouseEntityLook = null, BasicGuildInformations guildInfo = null, int alignmentSide = 0)
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
		}

	}
}
