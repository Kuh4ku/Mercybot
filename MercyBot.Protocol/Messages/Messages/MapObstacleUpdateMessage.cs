using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MapObstacleUpdateMessage : Message
	{

		// Properties
		public List<MapObstacle> Obstacles { get; set; }


		// Constructors
		public MapObstacleUpdateMessage() { }

		public MapObstacleUpdateMessage(List<MapObstacle> obstacles = null)
		{
			Obstacles = obstacles;
		}

	}
}
