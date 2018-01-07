using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceFactsMessage : Message
	{

		// Properties
		public List<GuildInAllianceInformations> Guilds { get; set; }
		public List<uint> ControlledSubareaIds { get; set; }
		public AllianceFactSheetInformations Infos { get; set; }


		// Constructors
		public AllianceFactsMessage() { }

		public AllianceFactsMessage(AllianceFactSheetInformations infos = null, List<GuildInAllianceInformations> guilds = null, List<uint> controlledSubareaIds = null)
		{
			Infos = infos;
			Guilds = guilds;
			ControlledSubareaIds = controlledSubareaIds;
		}

	}
}
