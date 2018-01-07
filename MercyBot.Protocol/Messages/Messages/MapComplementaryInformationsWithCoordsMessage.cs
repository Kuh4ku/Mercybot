using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MapComplementaryInformationsWithCoordsMessage : MapComplementaryInformationsDataMessage
	{

		// Properties
		public int WorldX { get; set; }
		public int WorldY { get; set; }


		// Constructors
		public MapComplementaryInformationsWithCoordsMessage() { }

		public MapComplementaryInformationsWithCoordsMessage(uint subAreaId = 0, uint mapId = 0, int worldX = 0, int worldY = 0, List<HouseInformations> houses = null, List<GameRolePlayActorInformations> actors = null, List<InteractiveElement> interactiveElements = null, List<StatedElement> statedElements = null, List<MapObstacle> obstacles = null, List<FightCommonInformations> fights = null)
		{
			SubAreaId = subAreaId;
			MapId = mapId;
			WorldX = worldX;
			WorldY = worldY;
			Houses = houses;
			Actors = actors;
			InteractiveElements = interactiveElements;
			StatedElements = statedElements;
			Obstacles = obstacles;
			Fights = fights;
		}

	}
}
