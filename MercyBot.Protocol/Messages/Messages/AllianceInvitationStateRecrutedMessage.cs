using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceInvitationStateRecrutedMessage : Message
	{

		// Properties
		public uint InvitationState { get; set; }


		// Constructors
		public AllianceInvitationStateRecrutedMessage() { }

		public AllianceInvitationStateRecrutedMessage(uint invitationState = 0)
		{
			InvitationState = invitationState;
		}

	}
}
