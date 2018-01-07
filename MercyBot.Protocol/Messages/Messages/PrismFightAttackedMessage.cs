using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismFightAttackedMessage : Message
	{

		// Properties
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public int MapId { get; set; }
		public uint SubAreaId { get; set; }
		public int PrismSide { get; set; }


		// Constructors
		public PrismFightAttackedMessage() { }

		public PrismFightAttackedMessage(int worldX = 0, int worldY = 0, int mapId = 0, uint subAreaId = 0, int prismSide = 0)
		{
			WorldX = worldX;
			WorldY = worldY;
			MapId = mapId;
			SubAreaId = subAreaId;
			PrismSide = prismSide;
		}

	}
}
