using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class FriendsListMessage : Message
	{

		// Properties
		public List<FriendInformations> FriendsList { get; set; }


		// Constructors
		public FriendsListMessage() { }

		public FriendsListMessage(List<FriendInformations> friendsList = null)
		{
			FriendsList = friendsList;
		}

	}
}
