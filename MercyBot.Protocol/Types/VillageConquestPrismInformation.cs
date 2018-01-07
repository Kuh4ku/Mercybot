using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class VillageConquestPrismInformation
	{

		// Properties
		public uint AreaId { get; set; }
		public uint AreaAlignment { get; set; }
		public bool IsEntered { get; set; }
		public bool IsInRoom { get; set; }


		// Constructors
		public VillageConquestPrismInformation() { }

		public VillageConquestPrismInformation(uint areaId = 0, uint areaAlignment = 0, bool isEntered = false, bool isInRoom = false)
		{
			AreaId = areaId;
			AreaAlignment = areaAlignment;
			IsEntered = isEntered;
			IsInRoom = isInRoom;
		}

	}
}
