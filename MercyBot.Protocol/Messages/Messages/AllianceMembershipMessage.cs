using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceMembershipMessage : AllianceJoinedMessage
	{

		// Constructors
		public AllianceMembershipMessage() { }

		public AllianceMembershipMessage(AllianceInformations allianceInfo = null, bool enabled = false)
		{
			AllianceInfo = allianceInfo;
			Enabled = enabled;
		}

	}
}
