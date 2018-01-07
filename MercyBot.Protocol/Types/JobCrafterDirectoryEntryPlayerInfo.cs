using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class JobCrafterDirectoryEntryPlayerInfo
	{

		// Properties
		public uint PlayerId { get; set; }
		public string PlayerName { get; set; }
		public int AlignmentSide { get; set; }
		public int Breed { get; set; }
		public bool Sex { get; set; }
		public bool IsInWorkshop { get; set; }
		public int WorldX { get; set; }
		public int WorldY { get; set; }
		public int MapId { get; set; }
		public uint SubAreaId { get; set; }
		public PlayerStatus Status { get; set; }


		// Constructors
		public JobCrafterDirectoryEntryPlayerInfo() { }

		public JobCrafterDirectoryEntryPlayerInfo(uint playerId = 0, string playerName = "", int alignmentSide = 0, int breed = 0, bool sex = false, bool isInWorkshop = false, int worldX = 0, int worldY = 0, int mapId = 0, uint subAreaId = 0, PlayerStatus status = null)
		{
			PlayerId = playerId;
			PlayerName = playerName;
			AlignmentSide = alignmentSide;
			Breed = breed;
			Sex = sex;
			IsInWorkshop = isInWorkshop;
			WorldX = worldX;
			WorldY = worldY;
			MapId = mapId;
			SubAreaId = subAreaId;
			Status = status;
		}

	}
}
