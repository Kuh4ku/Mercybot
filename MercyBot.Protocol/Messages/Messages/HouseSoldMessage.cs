using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class HouseSoldMessage : Message
	{

		// Properties
		public uint HouseId { get; set; }
		public uint RealPrice { get; set; }
		public string BuyerName { get; set; }


		// Constructors
		public HouseSoldMessage() { }

		public HouseSoldMessage(uint houseId = 0, uint realPrice = 0, string buyerName = "")
		{
			HouseId = houseId;
			RealPrice = realPrice;
			BuyerName = buyerName;
		}

	}
}
