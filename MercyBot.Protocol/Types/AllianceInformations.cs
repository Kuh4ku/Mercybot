using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class AllianceInformations : BasicNamedAllianceInformations
	{

		// Properties
		public GuildEmblem AllianceEmblem { get; set; }


		// Constructors
		public AllianceInformations() { }

		public AllianceInformations(uint allianceId = 0, string allianceTag = "", string allianceName = "", GuildEmblem allianceEmblem = null)
		{
			AllianceId = allianceId;
			AllianceTag = allianceTag;
			AllianceName = allianceName;
			AllianceEmblem = allianceEmblem;
		}

	}
}
