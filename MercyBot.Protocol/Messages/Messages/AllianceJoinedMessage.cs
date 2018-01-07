using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AllianceJoinedMessage : Message
	{

		// Properties
		public AllianceInformations AllianceInfo { get; set; }
		public bool Enabled { get; set; }


		// Constructors
		public AllianceJoinedMessage() { }

		public AllianceJoinedMessage(AllianceInformations allianceInfo = null, bool enabled = false)
		{
			AllianceInfo = allianceInfo;
			Enabled = enabled;
		}

	}
}
