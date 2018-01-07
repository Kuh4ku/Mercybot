using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class TaxCollectorStaticInformations
	{

		// Properties
		public uint FirstNameId { get; set; }
		public uint LastNameId { get; set; }
		public GuildInformations GuildIdentity { get; set; }


		// Constructors
		public TaxCollectorStaticInformations() { }

		public TaxCollectorStaticInformations(uint firstNameId = 0, uint lastNameId = 0, GuildInformations guildIdentity = null)
		{
			FirstNameId = firstNameId;
			LastNameId = lastNameId;
			GuildIdentity = guildIdentity;
		}

	}
}
