using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CompassUpdatePartyMemberMessage : CompassUpdateMessage
	{

		// Properties
		public uint MemberId { get; set; }


		// Constructors
		public CompassUpdatePartyMemberMessage() { }

		public CompassUpdatePartyMemberMessage(uint type = 0, MapCoordinates coords = null, uint memberId = 0)
		{
			Type = type;
			Coords = coords;
			MemberId = memberId;
		}

	}
}
