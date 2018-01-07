using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class FriendSpouseFollowWithCompassRequestMessage : Message
	{

		// Properties
		public bool Enable { get; set; }


		// Constructors
		public FriendSpouseFollowWithCompassRequestMessage() { }

		public FriendSpouseFollowWithCompassRequestMessage(bool enable = false)
		{
			Enable = enable;
		}

	}
}
