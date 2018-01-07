using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class FriendAddRequestMessage : Message
	{

		// Properties
		public string Name { get; set; }


		// Constructors
		public FriendAddRequestMessage() { }

		public FriendAddRequestMessage(string name = "")
		{
			Name = name;
		}

	}
}
