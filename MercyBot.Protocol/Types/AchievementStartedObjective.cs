using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class AchievementStartedObjective : AchievementObjective
	{

		// Properties
		public uint Value { get; set; }


		// Constructors
		public AchievementStartedObjective() { }

		public AchievementStartedObjective(uint id = 0, uint maxValue = 0, uint value = 0)
		{
			Id = id;
			MaxValue = maxValue;
			Value = value;
		}

	}
}
