using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class HouseInformationsForGuild
	{

		// Properties
		public List<int> SkillListIds { get; set; }
		public uint HouseId { get; set; }
		public uint ModelId { get; set; }
		public string OwnerName { get; set; }
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public int MapId { get; set; }
		public uint SubAreaId { get; set; }
		public uint GuildshareParams { get; set; }


		// Constructors
		public HouseInformationsForGuild() { }

		public HouseInformationsForGuild(uint houseId = 0, uint modelId = 0, string ownerName = "", int worldX = 0, int worldY = 0, int mapId = 0, uint subAreaId = 0, uint guildshareParams = 0, List<int> skillListIds = null)
		{
			HouseId = houseId;
			ModelId = modelId;
			OwnerName = ownerName;
			WorldX = worldX;
			WorldY = worldY;
			MapId = mapId;
			SubAreaId = subAreaId;
			GuildshareParams = guildshareParams;
			SkillListIds = skillListIds;
		}

	}
}
