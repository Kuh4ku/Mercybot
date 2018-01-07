using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class TaxCollectorStaticExtendedInformations : TaxCollectorStaticInformations
	{

		// Properties
		public AllianceInformations AllianceIdentity { get; set; }


		// Constructors
		public TaxCollectorStaticExtendedInformations() { }

		public TaxCollectorStaticExtendedInformations(uint firstNameId = 0, uint lastNameId = 0, GuildInformations guildIdentity = null, AllianceInformations allianceIdentity = null)
		{
			FirstNameId = firstNameId;
			LastNameId = lastNameId;
			GuildIdentity = guildIdentity;
			AllianceIdentity = allianceIdentity;
		}

	}
}
