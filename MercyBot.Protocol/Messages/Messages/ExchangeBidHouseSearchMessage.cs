using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeBidHouseSearchMessage : Message
	{

		// Properties
		public uint Type { get; set; }
		public uint GenId { get; set; }


		// Constructors
		public ExchangeBidHouseSearchMessage() { }

		public ExchangeBidHouseSearchMessage(uint type = 0, uint genId = 0)
		{
			Type = type;
			GenId = genId;
		}

	}
}
