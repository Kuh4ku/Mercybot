using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GuildInsiderFactSheetInformations : GuildFactSheetInformations
	{

		// Properties
		public string LeaderName { get; set; }
		public uint NbConnectedMembers { get; set; }
		public uint NbTaxCollectors { get; set; }
		public uint LastActivity { get; set; }
		public bool Enabled { get; set; }


		// Constructors
		public GuildInsiderFactSheetInformations() { }

		public GuildInsiderFactSheetInformations(uint guildId = 0, string guildName = "", GuildEmblem guildEmblem = null, uint leaderId = 0, uint guildLevel = 0, uint nbMembers = 0, string leaderName = "", uint nbConnectedMembers = 0, uint nbTaxCollectors = 0, uint lastActivity = 0, bool enabled = false)
		{
			GuildId = guildId;
			GuildName = guildName;
			GuildEmblem = guildEmblem;
			LeaderId = leaderId;
			GuildLevel = guildLevel;
			NbMembers = nbMembers;
			LeaderName = leaderName;
			NbConnectedMembers = nbConnectedMembers;
			NbTaxCollectors = nbTaxCollectors;
			LastActivity = lastActivity;
			Enabled = enabled;
		}

	}
}
