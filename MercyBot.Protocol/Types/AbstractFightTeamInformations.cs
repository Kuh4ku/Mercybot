using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class AbstractFightTeamInformations
	{

		// Properties
		public uint TeamId { get; set; }
		public int LeaderId { get; set; }
		public int TeamSide { get; set; }
		public uint TeamTypeId { get; set; }


		// Constructors
		public AbstractFightTeamInformations() { }

		public AbstractFightTeamInformations(uint teamId = 2, int leaderId = 0, int teamSide = 0, uint teamTypeId = 0)
		{
			TeamId = teamId;
			LeaderId = leaderId;
			TeamSide = teamSide;
			TeamTypeId = teamTypeId;
		}

	}
}
