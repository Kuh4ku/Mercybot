using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CurrentMapMessage : Message
	{

		// Properties
		public uint MapId { get; set; }
		public string MapKey { get; set; }


		// Constructors
		public CurrentMapMessage() { }

		public CurrentMapMessage(uint mapId = 0, string mapKey = "")
		{
			MapId = mapId;
			MapKey = mapKey;
		}

	}
}
