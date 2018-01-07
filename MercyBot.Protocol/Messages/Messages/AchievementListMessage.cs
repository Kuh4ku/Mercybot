using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AchievementListMessage : Message
	{

		// Properties
		public List<uint> FinishedAchievementsIds { get; set; }
		public List<AchievementRewardable> RewardableAchievements { get; set; }


		// Constructors
		public AchievementListMessage() { }

		public AchievementListMessage(List<uint> finishedAchievementsIds = null, List<AchievementRewardable> rewardableAchievements = null)
		{
			FinishedAchievementsIds = finishedAchievementsIds;
			RewardableAchievements = rewardableAchievements;
		}

	}
}
