using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AchievementDetailedListMessage : Message
	{

		// Properties
		public List<Achievement> StartedAchievements { get; set; }
		public List<Achievement> FinishedAchievements { get; set; }


		// Constructors
		public AchievementDetailedListMessage() { }

		public AchievementDetailedListMessage(List<Achievement> startedAchievements = null, List<Achievement> finishedAchievements = null)
		{
			StartedAchievements = startedAchievements;
			FinishedAchievements = finishedAchievements;
		}

	}
}
