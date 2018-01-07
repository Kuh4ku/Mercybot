using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FriendOnlineInformations : FriendInformations
	{

		// Properties
		public uint PlayerId { get; set; }
		public string PlayerName { get; set; }
		public uint Level { get; set; }
		public int AlignmentSide { get; set; }
		public int Breed { get; set; }
		public bool Sex { get; set; }
		public BasicGuildInformations GuildInfo { get; set; }
		public int MoodSmileyId { get; set; }
		public PlayerStatus Status { get; set; }


		// Constructors
		public FriendOnlineInformations() { }

		public FriendOnlineInformations(uint accountId = 0, string accountName = "", uint playerState = 99, uint lastConnection = 0, int achievementPoints = 0, uint playerId = 0, string playerName = "", uint level = 0, int alignmentSide = 0, int breed = 0, bool sex = false, BasicGuildInformations guildInfo = null, int moodSmileyId = 0, PlayerStatus status = null)
		{
			AccountId = accountId;
			AccountName = accountName;
			PlayerState = playerState;
			LastConnection = lastConnection;
			AchievementPoints = achievementPoints;
			PlayerId = playerId;
			PlayerName = playerName;
			Level = level;
			AlignmentSide = alignmentSide;
			Breed = breed;
			Sex = sex;
			GuildInfo = guildInfo;
			MoodSmileyId = moodSmileyId;
			Status = status;
		}

	}
}
