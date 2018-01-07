using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class SkillActionDescriptionCollect : SkillActionDescriptionTimed
	{

		// Properties
		public uint Min { get; set; }
		public uint Max { get; set; }


		// Constructors
		public SkillActionDescriptionCollect() { }

		public SkillActionDescriptionCollect(uint skillId = 0, uint time = 0, uint min = 0, uint max = 0)
		{
			SkillId = skillId;
			Time = time;
			Min = min;
			Max = max;
		}

	}
}
