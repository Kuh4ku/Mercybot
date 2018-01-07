using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class BasicGuildInformations : AbstractSocialGroupInfos
	{

		// Properties
		public uint GuildId { get; set; }
		public string GuildName { get; set; }


		// Constructors
		public BasicGuildInformations() { }

		public BasicGuildInformations(uint guildId = 0, string guildName = "")
		{
			GuildId = guildId;
			GuildName = guildName;
		}

	}
}
