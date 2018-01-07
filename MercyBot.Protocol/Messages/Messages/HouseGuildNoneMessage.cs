using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class HouseGuildNoneMessage : Message
	{

		// Properties
		public uint HouseId { get; set; }


		// Constructors
		public HouseGuildNoneMessage() { }

		public HouseGuildNoneMessage(uint houseId = 0)
		{
			HouseId = houseId;
		}

	}
}
