using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MountFeedRequestMessage : Message
	{

		// Properties
		public double MountUid { get; set; }
		public int MountLocation { get; set; }
		public uint MountFoodUid { get; set; }
		public uint Quantity { get; set; }


		// Constructors
		public MountFeedRequestMessage() { }

		public MountFeedRequestMessage(double mountUid = 0, int mountLocation = 0, uint mountFoodUid = 0, uint quantity = 0)
		{
			MountUid = mountUid;
			MountLocation = mountLocation;
			MountFoodUid = mountFoodUid;
			Quantity = quantity;
		}

	}
}
