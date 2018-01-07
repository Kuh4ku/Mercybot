using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class FriendDeleteRequestMessage : Message
	{

		// Properties
		public uint AccountId { get; set; }


		// Constructors
		public FriendDeleteRequestMessage() { }

		public FriendDeleteRequestMessage(uint accountId = 0)
		{
			AccountId = accountId;
		}

	}
}
