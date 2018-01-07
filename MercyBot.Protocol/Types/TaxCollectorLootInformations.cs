using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class TaxCollectorLootInformations : TaxCollectorComplementaryInformations
	{

		// Properties
		public uint Kamas { get; set; }
		public double Experience { get; set; }
		public uint Pods { get; set; }
		public uint ItemsValue { get; set; }


		// Constructors
		public TaxCollectorLootInformations() { }

		public TaxCollectorLootInformations(uint kamas = 0, double experience = 0, uint pods = 0, uint itemsValue = 0)
		{
			Kamas = kamas;
			Experience = experience;
			Pods = pods;
			ItemsValue = itemsValue;
		}

	}
}
