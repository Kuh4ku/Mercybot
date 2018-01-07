using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MapComplementaryInformationsDataInHouseMessage : MapComplementaryInformationsDataMessage
	{

		// Properties
		public HouseInformationsInside CurrentHouse { get; set; }


		// Constructors
		public MapComplementaryInformationsDataInHouseMessage() { }

		public MapComplementaryInformationsDataInHouseMessage(uint subAreaId = 0, uint mapId = 0, HouseInformationsInside currentHouse = null, List<HouseInformations> houses = null, List<GameRolePlayActorInformations> actors = null, List<InteractiveElement> interactiveElements = null, List<StatedElement> statedElements = null, List<MapObstacle> obstacles = null, List<FightCommonInformations> fights = null)
		{
			SubAreaId = subAreaId;
			MapId = mapId;
			CurrentHouse = currentHouse;
			Houses = houses;
			Actors = actors;
			InteractiveElements = interactiveElements;
			StatedElements = statedElements;
			Obstacles = obstacles;
			Fights = fights;
		}

	}
}
