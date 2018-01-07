using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PaddockContentInformations : PaddockInformations
	{

		// Properties
		public List<MountInformationsForPaddock> MountsInformations { get; set; }
		public int PaddockId { get; set; }
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public int MapId { get; set; }
		public uint SubAreaId { get; set; }
		public bool Abandonned { get; set; }


		// Constructors
		public PaddockContentInformations() { }

		public PaddockContentInformations(uint maxOutdoorMount = 0, uint maxItems = 0, int paddockId = 0, int worldX = 0, int worldY = 0, int mapId = 0, uint subAreaId = 0, bool abandonned = false, List<MountInformationsForPaddock> mountsInformations = null)
		{
			MaxOutdoorMount = maxOutdoorMount;
			MaxItems = maxItems;
			PaddockId = paddockId;
			WorldX = worldX;
			WorldY = worldY;
			MapId = mapId;
			SubAreaId = subAreaId;
			Abandonned = abandonned;
			MountsInformations = mountsInformations;
		}

	}
}
