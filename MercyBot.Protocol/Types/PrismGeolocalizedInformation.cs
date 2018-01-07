using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PrismGeolocalizedInformation : PrismSubareaEmptyInfo
	{

		// Properties
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public int MapId { get; set; }
		public PrismInformation Prism { get; set; }


		// Constructors
		public PrismGeolocalizedInformation() { }

		public PrismGeolocalizedInformation(uint subAreaId = 0, uint allianceId = 0, int worldX = 0, int worldY = 0, int mapId = 0, PrismInformation prism = null)
		{
			SubAreaId = subAreaId;
			AllianceId = allianceId;
			WorldX = worldX;
			WorldY = worldY;
			MapId = mapId;
			Prism = prism;
		}

	}
}
