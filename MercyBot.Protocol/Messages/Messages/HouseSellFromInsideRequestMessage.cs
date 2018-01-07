using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class HouseSellFromInsideRequestMessage : HouseSellRequestMessage
	{

		// Constructors
		public HouseSellFromInsideRequestMessage() { }

		public HouseSellFromInsideRequestMessage(uint amount = 0)
		{
			Amount = amount;
		}

	}
}
