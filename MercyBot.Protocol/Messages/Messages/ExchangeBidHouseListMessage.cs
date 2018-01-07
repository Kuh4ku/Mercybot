using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeBidHouseListMessage : Message
	{

		// Properties
		public uint Id { get; set; }


		// Constructors
		public ExchangeBidHouseListMessage() { }

		public ExchangeBidHouseListMessage(uint id = 0)
		{
			Id = id;
		}

	}
}
