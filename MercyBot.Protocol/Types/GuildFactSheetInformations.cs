using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GuildFactSheetInformations : GuildInformations
	{

		// Properties
		public uint LeaderId { get; set; }
		public uint GuildLevel { get; set; }
		public uint NbMembers { get; set; }


		// Constructors
		public GuildFactSheetInformations() { }

		public GuildFactSheetInformations(uint guildId = 0, string guildName = "", GuildEmblem guildEmblem = null, uint leaderId = 0, uint guildLevel = 0, uint nbMembers = 0)
		{
			GuildId = guildId;
			GuildName = guildName;
			GuildEmblem = guildEmblem;
			LeaderId = leaderId;
			GuildLevel = guildLevel;
			NbMembers = nbMembers;
		}

	}
}
