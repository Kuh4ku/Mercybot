using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class HouseBuyResultMessage : Message
	{

		// Properties
		public uint HouseId { get; set; }
		public bool Bought { get; set; }
		public uint RealPrice { get; set; }


		// Constructors
		public HouseBuyResultMessage() { }

		public HouseBuyResultMessage(uint houseId = 0, bool bought = false, uint realPrice = 0)
		{
			HouseId = houseId;
			Bought = bought;
			RealPrice = realPrice;
		}

	}
}
