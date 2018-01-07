using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class CompassUpdatePvpSeekMessage : CompassUpdateMessage
	{

		// Properties
		public uint MemberId { get; set; }
		public string MemberName { get; set; }


		// Constructors
		public CompassUpdatePvpSeekMessage() { }

		public CompassUpdatePvpSeekMessage(uint type = 0, MapCoordinates coords = null, uint memberId = 0, string memberName = "")
		{
			Type = type;
			Coords = coords;
			MemberId = memberId;
			MemberName = memberName;
		}

	}
}
