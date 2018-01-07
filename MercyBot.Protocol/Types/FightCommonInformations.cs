using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightCommonInformations
	{

		// Properties
		public List<FightTeamInformations> FightTeams { get; set; }
		public List<uint> FightTeamsPositions { get; set; }
		public List<FightOptionsInformations> FightTeamsOptions { get; set; }
		public int FightId { get; set; }
		public uint FightType { get; set; }


		// Constructors
		public FightCommonInformations() { }

		public FightCommonInformations(int fightId = 0, uint fightType = 0, List<FightTeamInformations> fightTeams = null, List<uint> fightTeamsPositions = null, List<FightOptionsInformations> fightTeamsOptions = null)
		{
			FightId = fightId;
			FightType = fightType;
			FightTeams = fightTeams;
			FightTeamsPositions = fightTeamsPositions;
			FightTeamsOptions = fightTeamsOptions;
		}

	}
}
