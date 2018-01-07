using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class FriendDeleteResultMessage : Message
	{

		// Properties
		public bool Success { get; set; }
		public string Name { get; set; }


		// Constructors
		public FriendDeleteResultMessage() { }

		public FriendDeleteResultMessage(bool success = false, string name = "")
		{
			Success = success;
			Name = name;
		}

	}
}
