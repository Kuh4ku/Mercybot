using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightAllianceTeamInformations : FightTeamInformations
	{

		// Properties
		public uint Relation { get; set; }


		// Constructors
		public FightAllianceTeamInformations() { }

		public FightAllianceTeamInformations(uint teamId = 2, int leaderId = 0, int teamSide = 0, uint teamTypeId = 0, uint relation = 0, List<FightTeamMemberInformations> teamMembers = null)
		{
			TeamId = teamId;
			LeaderId = leaderId;
			TeamSide = teamSide;
			TeamTypeId = teamTypeId;
			Relation = relation;
			TeamMembers = teamMembers;
		}

	}
}
