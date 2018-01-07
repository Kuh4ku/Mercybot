using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AchievementDetailsRequestMessage : Message
	{

		// Properties
		public uint AchievementId { get; set; }


		// Constructors
		public AchievementDetailsRequestMessage() { }

		public AchievementDetailsRequestMessage(uint achievementId = 0)
		{
			AchievementId = achievementId;
		}

	}
}
