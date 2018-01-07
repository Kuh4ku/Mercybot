using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AchievementDetailsMessage : Message
	{

		// Properties
		public Achievement Achievement { get; set; }


		// Constructors
		public AchievementDetailsMessage() { }

		public AchievementDetailsMessage(Achievement achievement = null)
		{
			Achievement = achievement;
		}

	}
}
