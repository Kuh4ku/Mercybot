using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceCreationValidMessage : Message
	{

		// Properties
		public string AllianceName { get; set; }
		public string AllianceTag { get; set; }
		public GuildEmblem AllianceEmblem { get; set; }


		// Constructors
		public AllianceCreationValidMessage() { }

		public AllianceCreationValidMessage(string allianceName = "", string allianceTag = "", GuildEmblem allianceEmblem = null)
		{
			AllianceName = allianceName;
			AllianceTag = allianceTag;
			AllianceEmblem = allianceEmblem;
		}

	}
}
