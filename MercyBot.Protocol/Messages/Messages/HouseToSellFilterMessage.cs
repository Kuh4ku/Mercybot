using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class HouseToSellFilterMessage : Message
	{

		// Properties
		public int AreaId { get; set; }
		public uint AtLeastNbRoom { get; set; }
		public uint AtLeastNbChest { get; set; }
		public uint SkillRequested { get; set; }
		public uint MaxPrice { get; set; }


		// Constructors
		public HouseToSellFilterMessage() { }

		public HouseToSellFilterMessage(int areaId = 0, uint atLeastNbRoom = 0, uint atLeastNbChest = 0, uint skillRequested = 0, uint maxPrice = 0)
		{
			AreaId = areaId;
			AtLeastNbRoom = atLeastNbRoom;
			AtLeastNbChest = atLeastNbChest;
			SkillRequested = skillRequested;
			MaxPrice = maxPrice;
		}

	}
}
