using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class BasicNamedAllianceInformations : BasicAllianceInformations
	{

		// Properties
		public string AllianceName { get; set; }


		// Constructors
		public BasicNamedAllianceInformations() { }

		public BasicNamedAllianceInformations(uint allianceId = 0, string allianceTag = "", string allianceName = "")
		{
			AllianceId = allianceId;
			AllianceTag = allianceTag;
			AllianceName = allianceName;
		}

	}
}
