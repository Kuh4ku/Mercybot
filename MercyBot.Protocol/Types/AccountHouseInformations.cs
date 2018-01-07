using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class AccountHouseInformations
	{

		// Properties
		public uint HouseId { get; set; }
		public uint ModelId { get; set; }
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public int MapId { get; set; }
		public uint SubAreaId { get; set; }


		// Constructors
		public AccountHouseInformations() { }

		public AccountHouseInformations(uint houseId = 0, uint modelId = 0, int worldX = 0, int worldY = 0, int mapId = 0, uint subAreaId = 0)
		{
			HouseId = houseId;
			ModelId = modelId;
			WorldX = worldX;
			WorldY = worldY;
			MapId = mapId;
			SubAreaId = subAreaId;
		}

	}
}
