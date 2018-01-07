using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PaddockBuyableInformations : PaddockInformations
	{

		// Properties
		public uint Price { get; set; }
		public bool Locked { get; set; }


		// Constructors
		public PaddockBuyableInformations() { }

		public PaddockBuyableInformations(uint maxOutdoorMount = 0, uint maxItems = 0, uint price = 0, bool locked = false)
		{
			MaxOutdoorMount = maxOutdoorMount;
			MaxItems = maxItems;
			Price = price;
			Locked = locked;
		}

	}
}
