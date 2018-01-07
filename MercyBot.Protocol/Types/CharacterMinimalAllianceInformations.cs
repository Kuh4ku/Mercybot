using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class CharacterMinimalAllianceInformations : CharacterMinimalGuildInformations
	{

		// Properties
		public BasicAllianceInformations Alliance { get; set; }


		// Constructors
		public CharacterMinimalAllianceInformations() { }

		public CharacterMinimalAllianceInformations(uint id = 0, uint level = 0, string name = "", EntityLook entityLook = null, BasicGuildInformations guild = null, BasicAllianceInformations alliance = null)
		{
			Id = id;
			Level = level;
			Name = name;
			EntityLook = entityLook;
			Guild = guild;
			Alliance = alliance;
		}

	}
}
