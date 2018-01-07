using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class FriendWarnOnConnectionStateMessage : Message
	{

		// Properties
		public bool Enable { get; set; }


		// Constructors
		public FriendWarnOnConnectionStateMessage() { }

		public FriendWarnOnConnectionStateMessage(bool enable = false)
		{
			Enable = enable;
		}

	}
}
