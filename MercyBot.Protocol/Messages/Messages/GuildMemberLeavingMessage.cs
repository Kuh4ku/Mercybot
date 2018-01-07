using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildMemberLeavingMessage : Message
	{

		// Properties
		public bool Kicked { get; set; }
		public int MemberId { get; set; }


		// Constructors
		public GuildMemberLeavingMessage() { }

		public GuildMemberLeavingMessage(bool kicked = false, int memberId = 0)
		{
			Kicked = kicked;
			MemberId = memberId;
		}

	}
}
