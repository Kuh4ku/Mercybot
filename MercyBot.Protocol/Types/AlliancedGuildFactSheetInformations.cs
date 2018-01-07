using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class AlliancedGuildFactSheetInformations : GuildInformations
	{

		// Properties
		public BasicNamedAllianceInformations AllianceInfos { get; set; }


		// Constructors
		public AlliancedGuildFactSheetInformations() { }

		public AlliancedGuildFactSheetInformations(uint guildId = 0, string guildName = "", GuildEmblem guildEmblem = null, BasicNamedAllianceInformations allianceInfos = null)
		{
			GuildId = guildId;
			GuildName = guildName;
			GuildEmblem = guildEmblem;
			AllianceInfos = allianceInfos;
		}

	}
}
