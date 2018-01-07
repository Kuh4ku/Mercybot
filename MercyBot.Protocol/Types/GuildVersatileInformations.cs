using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GuildVersatileInformations
	{

		// Properties
		public uint GuildId { get; set; }
		public uint LeaderId { get; set; }
		public uint GuildLevel { get; set; }
		public uint NbMembers { get; set; }


		// Constructors
		public GuildVersatileInformations() { }

		public GuildVersatileInformations(uint guildId = 0, uint leaderId = 0, uint guildLevel = 0, uint nbMembers = 0)
		{
			GuildId = guildId;
			LeaderId = leaderId;
			GuildLevel = guildLevel;
			NbMembers = nbMembers;
		}

	}
}
