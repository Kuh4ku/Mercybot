using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightTeamMemberMonsterInformations : FightTeamMemberInformations
	{

		// Properties
		public int MonsterId { get; set; }
		public uint Grade { get; set; }


		// Constructors
		public FightTeamMemberMonsterInformations() { }

		public FightTeamMemberMonsterInformations(int id = 0, int monsterId = 0, uint grade = 0)
		{
			Id = id;
			MonsterId = monsterId;
			Grade = grade;
		}

	}
}
