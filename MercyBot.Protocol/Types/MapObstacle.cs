using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class MapObstacle
	{

		// Properties
		public uint ObstacleCellId { get; set; }
		public uint State { get; set; }


		// Constructors
		public MapObstacle() { }

		public MapObstacle(uint obstacleCellId = 0, uint state = 0)
		{
			ObstacleCellId = obstacleCellId;
			State = state;
		}

	}
}
