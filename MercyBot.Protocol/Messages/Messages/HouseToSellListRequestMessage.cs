using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class HouseToSellListRequestMessage : Message
	{

		// Properties
		public uint PageIndex { get; set; }


		// Constructors
		public HouseToSellListRequestMessage() { }

		public HouseToSellListRequestMessage(uint pageIndex = 0)
		{
			PageIndex = pageIndex;
		}

	}
}
