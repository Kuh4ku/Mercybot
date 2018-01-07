using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartyInvitationArenaRequestMessage : PartyInvitationRequestMessage
	{

		// Constructors
		public PartyInvitationArenaRequestMessage() { }

		public PartyInvitationArenaRequestMessage(string name = "")
		{
			Name = name;
		}

	}
}
