using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class HouseInformationsInside
	{

		// Properties
		public uint HouseId { get; set; }
		public uint ModelId { get; set; }
		public int OwnerId { get; set; }
		public string OwnerName { get; set; }
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public uint Price { get; set; }
		public bool IsLocked { get; set; }


		// Constructors
		public HouseInformationsInside() { }

		public HouseInformationsInside(uint houseId = 0, uint modelId = 0, int ownerId = 0, string ownerName = "", int worldX = 0, int worldY = 0, uint price = 0, bool isLocked = false)
		{
			HouseId = houseId;
			ModelId = modelId;
			OwnerId = ownerId;
			OwnerName = ownerName;
			WorldX = worldX;
			WorldY = worldY;
			Price = price;
			IsLocked = isLocked;
		}

	}
}
