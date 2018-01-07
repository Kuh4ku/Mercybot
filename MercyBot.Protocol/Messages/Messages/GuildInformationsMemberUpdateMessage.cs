using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildInformationsMemberUpdateMessage : Message
	{

		// Properties
		public GuildMember Member { get; set; }


		// Constructors
		public GuildInformationsMemberUpdateMessage() { }

		public GuildInformationsMemberUpdateMessage(GuildMember member = null)
		{
			Member = member;
		}

	}
}
