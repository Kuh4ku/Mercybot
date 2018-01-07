using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class AchievementRewardable
	{

		// Properties
		public uint Id { get; set; }
		public uint Finishedlevel { get; set; }


		// Constructors
		public AchievementRewardable() { }

		public AchievementRewardable(uint id = 0, uint finishedlevel = 0)
		{
			Id = id;
			Finishedlevel = finishedlevel;
		}

	}
}
