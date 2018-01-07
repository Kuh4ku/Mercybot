using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class HouseInformationsExtended : HouseInformations
	{

		// Properties
		public GuildInformations GuildInfo { get; set; }


		// Constructors
		public HouseInformationsExtended() { }

		public HouseInformationsExtended(uint houseId = 0, string ownerName = "", bool isOnSale = false, bool isSaleLocked = false, uint modelId = 0, GuildInformations guildInfo = null, List<uint> doorsOnMap = null)
		{
			HouseId = houseId;
			OwnerName = ownerName;
			IsOnSale = isOnSale;
			IsSaleLocked = isSaleLocked;
			ModelId = modelId;
			GuildInfo = guildInfo;
			DoorsOnMap = doorsOnMap;
		}

	}
}
