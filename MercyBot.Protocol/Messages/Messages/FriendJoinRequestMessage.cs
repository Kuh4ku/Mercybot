using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class FriendJoinRequestMessage : Message
	{

		// Properties
		public string Name { get; set; }


		// Constructors
		public FriendJoinRequestMessage() { }

		public FriendJoinRequestMessage(string name = "")
		{
			Name = name;
		}

	}
}
