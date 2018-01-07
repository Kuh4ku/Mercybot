using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class KohUpdateMessage : Message
	{

		// Properties
		public List<AllianceInformations> Alliances { get; set; }
		public List<uint> AllianceNbMembers { get; set; }
		public List<uint> AllianceRoundWeigth { get; set; }
		public List<uint> AllianceMatchScore { get; set; }
		public BasicAllianceInformations AllianceMapWinner { get; set; }
		public uint AllianceMapWinnerScore { get; set; }
		public uint AllianceMapMyAllianceScore { get; set; }
		public double NextTickTime { get; set; }


		// Constructors
		public KohUpdateMessage() { }

		public KohUpdateMessage(BasicAllianceInformations allianceMapWinner = null, uint allianceMapWinnerScore = 0, uint allianceMapMyAllianceScore = 0, double nextTickTime = 0, List<AllianceInformations> alliances = null, List<uint> allianceNbMembers = null, List<uint> allianceRoundWeigth = null, List<uint> allianceMatchScore = null)
		{
			AllianceMapWinner = allianceMapWinner;
			AllianceMapWinnerScore = allianceMapWinnerScore;
			AllianceMapMyAllianceScore = allianceMapMyAllianceScore;
			NextTickTime = nextTickTime;
			Alliances = alliances;
			AllianceNbMembers = allianceNbMembers;
			AllianceRoundWeigth = allianceRoundWeigth;
			AllianceMatchScore = allianceMatchScore;
		}

	}
}
