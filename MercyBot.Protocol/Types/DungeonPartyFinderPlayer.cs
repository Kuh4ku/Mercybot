using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class DungeonPartyFinderPlayer
	{

		// Properties
		public uint PlayerId { get; set; }
		public string PlayerName { get; set; }
		public int Breed { get; set; }
		public bool Sex { get; set; }
		public uint Level { get; set; }


		// Constructors
		public DungeonPartyFinderPlayer() { }

		public DungeonPartyFinderPlayer(uint playerId = 0, string playerName = "", int breed = 0, bool sex = false, uint level = 0)
		{
			PlayerId = playerId;
			PlayerName = playerName;
			Breed = breed;
			Sex = sex;
			Level = level;
		}

	}
}
