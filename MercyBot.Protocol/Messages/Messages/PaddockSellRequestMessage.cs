using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PaddockSellRequestMessage : Message
	{

		// Properties
		public uint Price { get; set; }


		// Constructors
		public PaddockSellRequestMessage() { }

		public PaddockSellRequestMessage(uint price = 0)
		{
			Price = price;
		}

	}
}
