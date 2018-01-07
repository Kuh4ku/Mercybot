using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class FriendUpdateMessage : Message
	{

		// Properties
		public FriendInformations FriendUpdated { get; set; }


		// Constructors
		public FriendUpdateMessage() { }

		public FriendUpdateMessage(FriendInformations friendUpdated = null)
		{
			FriendUpdated = friendUpdated;
		}

	}
}
