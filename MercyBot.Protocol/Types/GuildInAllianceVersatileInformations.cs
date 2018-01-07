using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GuildInAllianceVersatileInformations : GuildVersatileInformations
	{

		// Properties
		public uint AllianceId { get; set; }


		// Constructors
		public GuildInAllianceVersatileInformations() { }

		public GuildInAllianceVersatileInformations(uint guildId = 0, uint leaderId = 0, uint guildLevel = 0, uint nbMembers = 0, uint allianceId = 0)
		{
			GuildId = guildId;
			LeaderId = leaderId;
			GuildLevel = guildLevel;
			NbMembers = nbMembers;
			AllianceId = allianceId;
		}

	}
}
