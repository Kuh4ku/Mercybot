using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class MapCoordinatesAndId : MapCoordinates
	{

		// Properties
		public int MapId { get; set; }


		// Constructors
		public MapCoordinatesAndId() { }

		public MapCoordinatesAndId(int worldX = 0, int worldY = 0, int mapId = 0)
		{
			WorldX = worldX;
			WorldY = worldY;
			MapId = mapId;
		}

	}
}
