using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class HouseSellRequestMessage : Message
	{

		// Properties
		public uint Amount { get; set; }


		// Constructors
		public HouseSellRequestMessage() { }

		public HouseSellRequestMessage(uint amount = 0)
		{
			Amount = amount;
		}

	}
}
