using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class HouseInformations
	{

		// Properties
		public List<uint> DoorsOnMap { get; set; }
		public uint HouseId { get; set; }
		public string OwnerName { get; set; }
		public bool IsOnSale { get; set; }
		public bool IsSaleLocked { get; set; }
		public uint ModelId { get; set; }


		// Constructors
		public HouseInformations() { }

		public HouseInformations(uint houseId = 0, string ownerName = "", bool isOnSale = false, bool isSaleLocked = false, uint modelId = 0, List<uint> doorsOnMap = null)
		{
			HouseId = houseId;
			OwnerName = ownerName;
			IsOnSale = isOnSale;
			IsSaleLocked = isSaleLocked;
			ModelId = modelId;
			DoorsOnMap = doorsOnMap;
		}

	}
}
