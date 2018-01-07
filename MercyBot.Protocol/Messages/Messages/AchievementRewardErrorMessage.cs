using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AchievementRewardErrorMessage : Message
	{

		// Properties
		public int AchievementId { get; set; }


		// Constructors
		public AchievementRewardErrorMessage() { }

		public AchievementRewardErrorMessage(int achievementId = 0)
		{
			AchievementId = achievementId;
		}

	}
}
