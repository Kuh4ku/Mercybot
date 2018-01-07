using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceModificationValidMessage : Message
	{

		// Properties
		public string AllianceName { get; set; }
		public string AllianceTag { get; set; }
		public GuildEmblem Alliancemblem { get; set; }


		// Constructors
		public AllianceModificationValidMessage() { }

		public AllianceModificationValidMessage(string allianceName = "", string allianceTag = "", GuildEmblem alliancemblem = null)
		{
			AllianceName = allianceName;
			AllianceTag = allianceTag;
			Alliancemblem = alliancemblem;
		}

	}
}
