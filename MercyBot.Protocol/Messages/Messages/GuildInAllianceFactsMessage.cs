using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildInAllianceFactsMessage : GuildFactsMessage
	{

		// Properties
		public BasicNamedAllianceInformations AllianceInfos { get; set; }


		// Constructors
		public GuildInAllianceFactsMessage() { }

		public GuildInAllianceFactsMessage(GuildFactSheetInformations infos = null, uint creationDate = 0, uint nbTaxCollectors = 0, bool enabled = false, BasicNamedAllianceInformations allianceInfos = null, List<CharacterMinimalInformations> members = null)
		{
			Infos = infos;
			CreationDate = creationDate;
			NbTaxCollectors = nbTaxCollectors;
			Enabled = enabled;
			AllianceInfos = allianceInfos;
			Members = members;
		}

	}
}
