using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildInvitationStateRecruterMessage : Message
	{

		// Properties
		public string RecrutedName { get; set; }
		public uint InvitationState { get; set; }


		// Constructors
		public GuildInvitationStateRecruterMessage() { }

		public GuildInvitationStateRecruterMessage(string recrutedName = "", uint invitationState = 0)
		{
			RecrutedName = recrutedName;
			InvitationState = invitationState;
		}

	}
}
