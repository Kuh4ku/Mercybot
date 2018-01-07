using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class InventoryWeightMessage : Message
	{

		// Properties
		public uint Weight { get; set; }
		public uint WeightMax { get; set; }


		// Constructors
		public InventoryWeightMessage() { }

		public InventoryWeightMessage(uint weight = 0, uint weightMax = 0)
		{
			Weight = weight;
			WeightMax = weightMax;
		}

	}
}
