using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class PaddockPrivateInformations : PaddockAbandonnedInformations
	{

		// Properties
		public GuildInformations GuildInfo { get; set; }


		// Constructors
		public PaddockPrivateInformations() { }

		public PaddockPrivateInformations(uint maxOutdoorMount = 0, uint maxItems = 0, uint price = 0, bool locked = false, int guildId = 0, GuildInformations guildInfo = null)
		{
			MaxOutdoorMount = maxOutdoorMount;
			MaxItems = maxItems;
			Price = price;
			Locked = locked;
			GuildId = guildId;
			GuildInfo = guildInfo;
		}

	}
}
