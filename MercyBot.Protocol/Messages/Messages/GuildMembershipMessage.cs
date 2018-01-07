using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildMembershipMessage : GuildJoinedMessage
	{

		// Constructors
		public GuildMembershipMessage() { }

		public GuildMembershipMessage(GuildInformations guildInfo = null, uint memberRights = 0, bool enabled = false)
		{
			GuildInfo = guildInfo;
			MemberRights = memberRights;
			Enabled = enabled;
		}

	}
}
