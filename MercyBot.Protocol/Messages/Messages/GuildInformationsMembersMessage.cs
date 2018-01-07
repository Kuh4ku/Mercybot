using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildInformationsMembersMessage : Message
	{

		// Properties
		public List<GuildMember> Members { get; set; }


		// Constructors
		public GuildInformationsMembersMessage() { }

		public GuildInformationsMembersMessage(List<GuildMember> members = null)
		{
			Members = members;
		}

	}
}
