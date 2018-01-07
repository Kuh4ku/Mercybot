using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AchievementRewardSuccessMessage : Message
	{

		// Properties
		public int AchievementId { get; set; }


		// Constructors
		public AchievementRewardSuccessMessage() { }

		public AchievementRewardSuccessMessage(int achievementId = 0)
		{
			AchievementId = achievementId;
		}

	}
}
