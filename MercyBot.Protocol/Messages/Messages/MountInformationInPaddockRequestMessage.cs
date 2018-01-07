using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MountInformationInPaddockRequestMessage : Message
	{

		// Properties
		public int MapRideId { get; set; }


		// Constructors
		public MountInformationInPaddockRequestMessage() { }

		public MountInformationInPaddockRequestMessage(int mapRideId = 0)
		{
			MapRideId = mapRideId;
		}

	}
}
