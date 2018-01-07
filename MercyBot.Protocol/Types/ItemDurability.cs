using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ItemDurability
	{

		// Properties
		public int Durability { get; set; }
		public int DurabilityMax { get; set; }


		// Constructors
		public ItemDurability() { }

		public ItemDurability(int durability = 0, int durabilityMax = 0)
		{
			Durability = durability;
			DurabilityMax = durabilityMax;
		}

	}
}
