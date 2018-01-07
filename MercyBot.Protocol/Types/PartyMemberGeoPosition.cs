using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PartyMemberGeoPosition
	{

		// Properties
		public uint MemberId { get; set; }
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public int MapId { get; set; }
		public uint SubAreaId { get; set; }


		// Constructors
		public PartyMemberGeoPosition() { }

		public PartyMemberGeoPosition(uint memberId = 0, int worldX = 0, int worldY = 0, int mapId = 0, uint subAreaId = 0)
		{
			MemberId = memberId;
			WorldX = worldX;
			WorldY = worldY;
			MapId = mapId;
			SubAreaId = subAreaId;
		}

	}
}
