using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildInvitationMessage : Message
	{

		// Properties
		public uint TargetId { get; set; }


		// Constructors
		public GuildInvitationMessage() { }

		public GuildInvitationMessage(uint targetId = 0)
		{
			TargetId = targetId;
		}

	}
}
