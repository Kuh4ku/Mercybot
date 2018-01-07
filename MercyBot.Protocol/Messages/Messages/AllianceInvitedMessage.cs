using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceInvitedMessage : Message
	{

		// Properties
		public uint RecruterId { get; set; }
		public string RecruterName { get; set; }
		public BasicNamedAllianceInformations AllianceInfo { get; set; }


		// Constructors
		public AllianceInvitedMessage() { }

		public AllianceInvitedMessage(uint recruterId = 0, string recruterName = "", BasicNamedAllianceInformations allianceInfo = null)
		{
			RecruterId = recruterId;
			RecruterName = recruterName;
			AllianceInfo = allianceInfo;
		}

	}
}
