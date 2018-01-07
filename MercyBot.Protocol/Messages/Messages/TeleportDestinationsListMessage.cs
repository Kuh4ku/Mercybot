using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TeleportDestinationsListMessage : Message
	{

		// Properties
		public List<uint> MapIds { get; set; }
		public List<uint> SubAreaIds { get; set; }
		public List<uint> Costs { get; set; }
		public List<uint> DestTeleporterType { get; set; }
		public uint TeleporterType { get; set; }


		// Constructors
		public TeleportDestinationsListMessage() { }

		public TeleportDestinationsListMessage(uint teleporterType = 0, List<uint> mapIds = null, List<uint> subAreaIds = null, List<uint> costs = null, List<uint> destTeleporterType = null)
		{
			TeleporterType = teleporterType;
			MapIds = mapIds;
			SubAreaIds = subAreaIds;
			Costs = costs;
			DestTeleporterType = destTeleporterType;
		}

	}
}
