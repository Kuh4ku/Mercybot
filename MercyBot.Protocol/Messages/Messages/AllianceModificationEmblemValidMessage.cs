using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceModificationEmblemValidMessage : Message
	{

		// Properties
		public GuildEmblem Alliancemblem { get; set; }


		// Constructors
		public AllianceModificationEmblemValidMessage() { }

		public AllianceModificationEmblemValidMessage(GuildEmblem alliancemblem = null)
		{
			Alliancemblem = alliancemblem;
		}

	}
}
