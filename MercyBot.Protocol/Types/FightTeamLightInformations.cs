using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightTeamLightInformations : AbstractFightTeamInformations
	{

		// Properties
		public uint TeamMembersCount { get; set; }
		public uint MeanLevel { get; set; }
		public bool HasFriend { get; set; }
		public bool HasGuildMember { get; set; }
		public bool HasAllianceMember { get; set; }
		public bool HasGroupMember { get; set; }
		public bool HasMyTaxCollector { get; set; }


		// Constructors
		public FightTeamLightInformations() { }

		public FightTeamLightInformations(uint teamId = 2, int leaderId = 0, int teamSide = 0, uint teamTypeId = 0, uint teamMembersCount = 0, uint meanLevel = 0, bool hasFriend = false, bool hasGuildMember = false, bool hasAllianceMember = false, bool hasGroupMember = false, bool hasMyTaxCollector = false)
		{
			TeamId = teamId;
			LeaderId = leaderId;
			TeamSide = teamSide;
			TeamTypeId = teamTypeId;
			TeamMembersCount = teamMembersCount;
			MeanLevel = meanLevel;
			HasFriend = hasFriend;
			HasGuildMember = hasGuildMember;
			HasAllianceMember = hasAllianceMember;
			HasGroupMember = hasGroupMember;
			HasMyTaxCollector = hasMyTaxCollector;
		}

	}
}
