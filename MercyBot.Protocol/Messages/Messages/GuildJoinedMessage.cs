using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildJoinedMessage : Message
	{

		// Properties
		public GuildInformations GuildInfo { get; set; }
		public uint MemberRights { get; set; }
		public bool Enabled { get; set; }


		// Constructors
		public GuildJoinedMessage() { }

		public GuildJoinedMessage(GuildInformations guildInfo = null, uint memberRights = 0, bool enabled = false)
		{
			GuildInfo = guildInfo;
			MemberRights = memberRights;
			Enabled = enabled;
		}

	}
}
