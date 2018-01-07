using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildMemberSetWarnOnConnectionMessage : Message
	{

		// Properties
		public bool Enable { get; set; }


		// Constructors
		public GuildMemberSetWarnOnConnectionMessage() { }

		public GuildMemberSetWarnOnConnectionMessage(bool enable = false)
		{
			Enable = enable;
		}

	}
}
