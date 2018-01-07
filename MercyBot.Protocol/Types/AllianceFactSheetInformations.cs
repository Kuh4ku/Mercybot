using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class AllianceFactSheetInformations : AllianceInformations
	{

		// Properties
		public uint CreationDate { get; set; }


		// Constructors
		public AllianceFactSheetInformations() { }

		public AllianceFactSheetInformations(uint allianceId = 0, string allianceTag = "", string allianceName = "", GuildEmblem allianceEmblem = null, uint creationDate = 0)
		{
			AllianceId = allianceId;
			AllianceTag = allianceTag;
			AllianceName = allianceName;
			AllianceEmblem = allianceEmblem;
			CreationDate = creationDate;
		}

	}
}
