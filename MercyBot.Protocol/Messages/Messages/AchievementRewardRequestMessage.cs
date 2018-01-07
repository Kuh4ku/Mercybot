using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AchievementRewardRequestMessage : Message
	{

		// Properties
		public int AchievementId { get; set; }


		// Constructors
		public AchievementRewardRequestMessage() { }

		public AchievementRewardRequestMessage(int achievementId = 0)
		{
			AchievementId = achievementId;
		}

	}
}
