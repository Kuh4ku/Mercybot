using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class FriendGuildWarnOnAchievementCompleteStateMessage : Message
	{

		// Properties
		public bool Enable { get; set; }


		// Constructors
		public FriendGuildWarnOnAchievementCompleteStateMessage() { }

		public FriendGuildWarnOnAchievementCompleteStateMessage(bool enable = false)
		{
			Enable = enable;
		}

	}
}
