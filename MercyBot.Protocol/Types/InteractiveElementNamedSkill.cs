using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class InteractiveElementNamedSkill : InteractiveElementSkill
	{

		// Properties
		public uint NameId { get; set; }


		// Constructors
		public InteractiveElementNamedSkill() { }

		public InteractiveElementNamedSkill(uint skillId = 0, uint skillInstanceUid = 0, uint nameId = 0)
		{
			SkillId = skillId;
			SkillInstanceUid = skillInstanceUid;
			NameId = nameId;
		}

	}
}
