using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PaddockInformations
	{

		// Properties
		public uint MaxOutdoorMount { get; set; }
		public uint MaxItems { get; set; }


		// Constructors
		public PaddockInformations() { }

		public PaddockInformations(uint maxOutdoorMount = 0, uint maxItems = 0)
		{
			MaxOutdoorMount = maxOutdoorMount;
			MaxItems = maxItems;
		}

	}
}
