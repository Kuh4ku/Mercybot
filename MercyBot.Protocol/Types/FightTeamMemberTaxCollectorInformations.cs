using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class FightTeamMemberTaxCollectorInformations : FightTeamMemberInformations
	{

		// Properties
		public uint FirstNameId { get; set; }
		public uint LastNameId { get; set; }
		public uint Level { get; set; }
		public uint GuildId { get; set; }
		public uint Uid { get; set; }


		// Constructors
		public FightTeamMemberTaxCollectorInformations() { }

		public FightTeamMemberTaxCollectorInformations(int id = 0, uint firstNameId = 0, uint lastNameId = 0, uint level = 0, uint guildId = 0, uint uid = 0)
		{
			Id = id;
			FirstNameId = firstNameId;
			LastNameId = lastNameId;
			Level = level;
			GuildId = guildId;
			Uid = uid;
		}

	}
}
