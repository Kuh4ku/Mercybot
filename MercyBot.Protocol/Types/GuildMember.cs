using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class GuildMember : CharacterMinimalInformations
	{

		// Properties
		public int Breed { get; set; }
		public bool Sex { get; set; }
		public uint Rank { get; set; }
		public double GivenExperience { get; set; }
		public uint ExperienceGivenPercent { get; set; }
		public uint Rights { get; set; }
		public uint Connected { get; set; }
		public int AlignmentSide { get; set; }
		public uint HoursSinceLastConnection { get; set; }
		public int MoodSmileyId { get; set; }
		public uint AccountId { get; set; }
		public int AchievementPoints { get; set; }
		public PlayerStatus Status { get; set; }


		// Constructors
		public GuildMember() { }

		public GuildMember(uint id = 0, uint level = 0, string name = "", int breed = 0, bool sex = false, uint rank = 0, double givenExperience = 0, uint experienceGivenPercent = 0, uint rights = 0, uint connected = 99, int alignmentSide = 0, uint hoursSinceLastConnection = 0, int moodSmileyId = 0, uint accountId = 0, int achievementPoints = 0, PlayerStatus status = null)
		{
			Id = id;
			Level = level;
			Name = name;
			Breed = breed;
			Sex = sex;
			Rank = rank;
			GivenExperience = givenExperience;
			ExperienceGivenPercent = experienceGivenPercent;
			Rights = rights;
			Connected = connected;
			AlignmentSide = alignmentSide;
			HoursSinceLastConnection = hoursSinceLastConnection;
			MoodSmileyId = moodSmileyId;
			AccountId = accountId;
			AchievementPoints = achievementPoints;
			Status = status;
		}

	}
}
