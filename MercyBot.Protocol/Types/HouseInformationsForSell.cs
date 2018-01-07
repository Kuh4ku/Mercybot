using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class HouseInformationsForSell
	{

		// Properties
		public List<int> SkillListIds { get; set; }
		public uint ModelId { get; set; }
		public string OwnerName { get; set; }
		public bool OwnerConnected { get; set; }
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public uint SubAreaId { get; set; }
		public int NbRoom { get; set; }
		public int NbChest { get; set; }
		public bool IsLocked { get; set; }
		public uint Price { get; set; }


		// Constructors
		public HouseInformationsForSell() { }

		public HouseInformationsForSell(uint modelId = 0, string ownerName = "", bool ownerConnected = false, int worldX = 0, int worldY = 0, uint subAreaId = 0, int nbRoom = 0, int nbChest = 0, bool isLocked = false, uint price = 0, List<int> skillListIds = null)
		{
			ModelId = modelId;
			OwnerName = ownerName;
			OwnerConnected = ownerConnected;
			WorldX = worldX;
			WorldY = worldY;
			SubAreaId = subAreaId;
			NbRoom = nbRoom;
			NbChest = nbChest;
			IsLocked = isLocked;
			Price = price;
			SkillListIds = skillListIds;
		}

	}
}
