using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class HouseKickRequestMessage : Message
	{

		// Properties
		public uint Id { get; set; }


		// Constructors
		public HouseKickRequestMessage() { }

		public HouseKickRequestMessage(uint id = 0)
		{
			Id = id;
		}

	}
}
