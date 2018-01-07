using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightExternalInformations
	{

		// Properties
		public List<FightTeamLightInformations> FightTeams { get; set; }
		public List<FightOptionsInformations> FightTeamsOptions { get; set; }
		public int FightId { get; set; }
		public uint FightType { get; set; }
		public uint FightStart { get; set; }
		public bool FightSpectatorLocked { get; set; }


		// Constructors
		public FightExternalInformations() { }

		public FightExternalInformations(int fightId = 0, uint fightType = 0, uint fightStart = 0, bool fightSpectatorLocked = false, List<FightTeamLightInformations> fightTeams = null, List<FightOptionsInformations> fightTeamsOptions = null)
		{
			FightId = fightId;
			FightType = fightType;
			FightStart = fightStart;
			FightSpectatorLocked = fightSpectatorLocked;
			FightTeams = fightTeams;
			FightTeamsOptions = fightTeamsOptions;
		}

	}
}
