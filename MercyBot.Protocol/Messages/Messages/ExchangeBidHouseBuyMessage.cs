using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeBidHouseBuyMessage : Message
	{

		// Properties
		public uint Uid { get; set; }
		public uint Qty { get; set; }
		public uint Price { get; set; }


		// Constructors
		public ExchangeBidHouseBuyMessage() { }

		public ExchangeBidHouseBuyMessage(uint uid = 0, uint qty = 0, uint price = 0)
		{
			Uid = uid;
			Qty = qty;
			Price = price;
		}

	}
}
