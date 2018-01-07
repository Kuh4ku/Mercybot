using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightTeamMemberCompanionInformations : FightTeamMemberInformations
	{

		// Properties
		public int CompanionId { get; set; }
		public uint Level { get; set; }
		public int MasterId { get; set; }


		// Constructors
		public FightTeamMemberCompanionInformations() { }

		public FightTeamMemberCompanionInformations(int id = 0, int companionId = 0, uint level = 0, int masterId = 0)
		{
			Id = id;
			CompanionId = companionId;
			Level = level;
			MasterId = masterId;
		}

	}
}
