using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChangeMapMessage : Message
	{

		// Properties
		public uint MapId { get; set; }


		// Constructors
		public ChangeMapMessage() { }

		public ChangeMapMessage(uint mapId = 0)
		{
			MapId = mapId;
		}

	}
}
