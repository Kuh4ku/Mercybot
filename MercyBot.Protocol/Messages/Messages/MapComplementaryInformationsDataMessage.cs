using System.Collections.Generic;
using MercyBot.Protocol.Types;
using Newtonsoft.Json;
using MercyBot.Protocol.Converters;

namespace MercyBot.Protocol.Messages
{
	public class MapComplementaryInformationsDataMessage : Message
	{

		// Properties
		public List<HouseInformations> Houses { get; set; }
        [JsonConverter(typeof(TypedPropertyConverter))]
		public List<GameRolePlayActorInformations> Actors { get; set; }
		public List<InteractiveElement> InteractiveElements { get; set; }
		public List<StatedElement> StatedElements { get; set; }
		public List<MapObstacle> Obstacles { get; set; }
		public List<FightCommonInformations> Fights { get; set; }
		public uint SubAreaId { get; set; }
		public uint MapId { get; set; }


		// Constructors
		public MapComplementaryInformationsDataMessage() { }

		public MapComplementaryInformationsDataMessage(uint subAreaId = 0, uint mapId = 0, List<HouseInformations> houses = null, List<GameRolePlayActorInformations> actors = null, List<InteractiveElement> interactiveElements = null, List<StatedElement> statedElements = null, List<MapObstacle> obstacles = null, List<FightCommonInformations> fights = null)
		{
			SubAreaId = subAreaId;
			MapId = mapId;
			Houses = houses;
			Actors = actors;
			InteractiveElements = interactiveElements;
			StatedElements = statedElements;
			Obstacles = obstacles;
			Fights = fights;
		}

	}
}
