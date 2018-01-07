using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildInvitationAnswerMessage : Message
	{

		// Properties
		public bool Accept { get; set; }


		// Constructors
		public GuildInvitationAnswerMessage() { }

		public GuildInvitationAnswerMessage(bool accept = false)
		{
			Accept = accept;
		}

	}
}
