using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildMemberOnlineStatusMessage : Message
	{

		// Properties
		public uint MemberId { get; set; }
		public bool Online { get; set; }


		// Constructors
		public GuildMemberOnlineStatusMessage() { }

		public GuildMemberOnlineStatusMessage(uint memberId = 0, bool online = false)
		{
			MemberId = memberId;
			Online = online;
		}

	}
}
