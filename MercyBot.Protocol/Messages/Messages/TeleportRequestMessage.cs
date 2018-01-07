using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TeleportRequestMessage : Message
	{

		// Properties
		public uint TeleporterType { get; set; }
		public uint MapId { get; set; }


		// Constructors
		public TeleportRequestMessage() { }

		public TeleportRequestMessage(uint teleporterType = 0, uint mapId = 0)
		{
			TeleporterType = teleporterType;
			MapId = mapId;
		}

	}
}
