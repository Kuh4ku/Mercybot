using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FriendInformations : AbstractContactInformations
	{

		// Properties
		public uint PlayerState { get; set; }
		public uint LastConnection { get; set; }
		public int AchievementPoints { get; set; }


		// Constructors
		public FriendInformations() { }

		public FriendInformations(uint accountId = 0, string accountName = "", uint playerState = 99, uint lastConnection = 0, int achievementPoints = 0)
		{
			AccountId = accountId;
			AccountName = accountName;
			PlayerState = playerState;
			LastConnection = lastConnection;
			AchievementPoints = achievementPoints;
		}

	}
}
