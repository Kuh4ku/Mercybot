using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildHouseRemoveMessage : Message
	{

		// Properties
		public uint HouseId { get; set; }


		// Constructors
		public GuildHouseRemoveMessage() { }

		public GuildHouseRemoveMessage(uint houseId = 0)
		{
			HouseId = houseId;
		}

	}
}
