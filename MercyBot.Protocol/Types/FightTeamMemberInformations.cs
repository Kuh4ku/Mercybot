using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightTeamMemberInformations
	{

		// Properties
		public int Id { get; set; }


		// Constructors
		public FightTeamMemberInformations() { }

		public FightTeamMemberInformations(int id = 0)
		{
			Id = id;
		}

	}
}
