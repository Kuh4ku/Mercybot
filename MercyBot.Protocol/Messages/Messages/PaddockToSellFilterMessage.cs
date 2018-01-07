using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PaddockToSellFilterMessage : Message
	{

		// Properties
		public int AreaId { get; set; }
		public int AtLeastNbMount { get; set; }
		public int AtLeastNbMachine { get; set; }
		public uint MaxPrice { get; set; }


		// Constructors
		public PaddockToSellFilterMessage() { }

		public PaddockToSellFilterMessage(int areaId = 0, int atLeastNbMount = 0, int atLeastNbMachine = 0, uint maxPrice = 0)
		{
			AreaId = areaId;
			AtLeastNbMount = atLeastNbMount;
			AtLeastNbMachine = atLeastNbMachine;
			MaxPrice = maxPrice;
		}

	}
}
