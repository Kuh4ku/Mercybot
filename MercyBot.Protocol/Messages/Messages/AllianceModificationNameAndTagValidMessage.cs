using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceModificationNameAndTagValidMessage : Message
	{

		// Properties
		public string AllianceName { get; set; }
		public string AllianceTag { get; set; }


		// Constructors
		public AllianceModificationNameAndTagValidMessage() { }

		public AllianceModificationNameAndTagValidMessage(string allianceName = "", string allianceTag = "")
		{
			AllianceName = allianceName;
			AllianceTag = allianceTag;
		}

	}
}
