using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildInvitationByNameMessage : Message
	{

		// Properties
		public string Name { get; set; }


		// Constructors
		public GuildInvitationByNameMessage() { }

		public GuildInvitationByNameMessage(string name = "")
		{
			Name = name;
		}

	}
}
