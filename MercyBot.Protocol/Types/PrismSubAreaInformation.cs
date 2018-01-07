using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PrismSubAreaInformation
	{

		// Properties
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public int MapId { get; set; }
		public uint SubAreaId { get; set; }
		public uint Alignment { get; set; }
		public bool IsInFight { get; set; }
		public bool IsFightable { get; set; }


		// Constructors
		public PrismSubAreaInformation() { }

		public PrismSubAreaInformation(int worldX = 0, int worldY = 0, int mapId = 0, uint subAreaId = 0, uint alignment = 0, bool isInFight = false, bool isFightable = false)
		{
			WorldX = worldX;
			WorldY = worldY;
			MapId = mapId;
			SubAreaId = subAreaId;
			Alignment = alignment;
			IsInFight = isInFight;
			IsFightable = isFightable;
		}

	}
}
