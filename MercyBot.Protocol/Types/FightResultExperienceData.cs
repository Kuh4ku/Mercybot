using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightResultExperienceData : FightResultAdditionalData
	{

		// Properties
		public double Experience { get; set; }
		public bool ShowExperience { get; set; }
		public double ExperienceLevelFloor { get; set; }
		public bool ShowExperienceLevelFloor { get; set; }
		public double ExperienceNextLevelFloor { get; set; }
		public bool ShowExperienceNextLevelFloor { get; set; }
		public int ExperienceFightDelta { get; set; }
		public bool ShowExperienceFightDelta { get; set; }
		public uint ExperienceForGuild { get; set; }
		public bool ShowExperienceForGuild { get; set; }
		public uint ExperienceForMount { get; set; }
		public bool ShowExperienceForMount { get; set; }
		public bool IsIncarnationExperience { get; set; }
		public int RerollExperienceMul { get; set; }


		// Constructors
		public FightResultExperienceData() { }

		public FightResultExperienceData(double experience = 0, bool showExperience = false, double experienceLevelFloor = 0, bool showExperienceLevelFloor = false, double experienceNextLevelFloor = 0, bool showExperienceNextLevelFloor = false, int experienceFightDelta = 0, bool showExperienceFightDelta = false, uint experienceForGuild = 0, bool showExperienceForGuild = false, uint experienceForMount = 0, bool showExperienceForMount = false, bool isIncarnationExperience = false, int rerollExperienceMul = 0)
		{
			Experience = experience;
			ShowExperience = showExperience;
			ExperienceLevelFloor = experienceLevelFloor;
			ShowExperienceLevelFloor = showExperienceLevelFloor;
			ExperienceNextLevelFloor = experienceNextLevelFloor;
			ShowExperienceNextLevelFloor = showExperienceNextLevelFloor;
			ExperienceFightDelta = experienceFightDelta;
			ShowExperienceFightDelta = showExperienceFightDelta;
			ExperienceForGuild = experienceForGuild;
			ShowExperienceForGuild = showExperienceForGuild;
			ExperienceForMount = experienceForMount;
			ShowExperienceForMount = showExperienceForMount;
			IsIncarnationExperience = isIncarnationExperience;
			RerollExperienceMul = rerollExperienceMul;
		}

	}
}
