using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PaddockAbandonnedInformations : PaddockBuyableInformations
	{

		// Properties
		public int GuildId { get; set; }


		// Constructors
		public PaddockAbandonnedInformations() { }

		public PaddockAbandonnedInformations(uint maxOutdoorMount = 0, uint maxItems = 0, uint price = 0, bool locked = false, int guildId = 0)
		{
			MaxOutdoorMount = maxOutdoorMount;
			MaxItems = maxItems;
			Price = price;
			Locked = locked;
			GuildId = guildId;
		}

	}
}
