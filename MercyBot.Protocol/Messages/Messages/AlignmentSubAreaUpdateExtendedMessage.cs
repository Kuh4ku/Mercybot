using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AlignmentSubAreaUpdateExtendedMessage : AlignmentSubAreaUpdateMessage
	{

		// Properties
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public int MapId { get; set; }
		public int EventType { get; set; }


		// Constructors
		public AlignmentSubAreaUpdateExtendedMessage() { }

		public AlignmentSubAreaUpdateExtendedMessage(uint subAreaId = 0, int side = 0, bool quiet = false, int worldX = 0, int worldY = 0, int mapId = 0, int eventType = 0)
		{
			SubAreaId = subAreaId;
			Side = side;
			Quiet = quiet;
			WorldX = worldX;
			WorldY = worldY;
			MapId = mapId;
			EventType = eventType;
		}

	}
}
