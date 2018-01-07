using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GuildInAllianceInformations : GuildInformations
	{

		// Properties
		public uint GuildLevel { get; set; }
		public uint NbMembers { get; set; }
		public bool Enabled { get; set; }


		// Constructors
		public GuildInAllianceInformations() { }

		public GuildInAllianceInformations(uint guildId = 0, string guildName = "", GuildEmblem guildEmblem = null, uint guildLevel = 0, uint nbMembers = 0, bool enabled = false)
		{
			GuildId = guildId;
			GuildName = guildName;
			GuildEmblem = guildEmblem;
			GuildLevel = guildLevel;
			NbMembers = nbMembers;
			Enabled = enabled;
		}

	}
}
