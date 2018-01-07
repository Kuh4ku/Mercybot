using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ZaapListMessage : TeleportDestinationsListMessage
	{

		// Properties
		public uint SpawnMapId { get; set; }


		// Constructors
		public ZaapListMessage() { }

		public ZaapListMessage(uint teleporterType = 0, uint spawnMapId = 0, List<uint> mapIds = null, List<uint> subAreaIds = null, List<uint> costs = null, List<uint> destTeleporterType = null)
		{
			TeleporterType = teleporterType;
			SpawnMapId = spawnMapId;
			MapIds = mapIds;
			SubAreaIds = subAreaIds;
			Costs = costs;
			DestTeleporterType = destTeleporterType;
		}

	}
}
