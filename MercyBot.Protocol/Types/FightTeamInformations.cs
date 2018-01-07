using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightTeamInformations : AbstractFightTeamInformations
	{

		// Properties
		public List<FightTeamMemberInformations> TeamMembers { get; set; }


		// Constructors
		public FightTeamInformations() { }

		public FightTeamInformations(uint teamId = 2, int leaderId = 0, int teamSide = 0, uint teamTypeId = 0, List<FightTeamMemberInformations> teamMembers = null)
		{
			TeamId = teamId;
			LeaderId = leaderId;
			TeamSide = teamSide;
			TeamTypeId = teamTypeId;
			TeamMembers = teamMembers;
		}

	}
}
