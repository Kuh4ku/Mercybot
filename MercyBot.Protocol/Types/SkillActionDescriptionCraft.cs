using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class SkillActionDescriptionCraft : SkillActionDescription
	{

		// Properties
		public uint MaxSlots { get; set; }
		public uint Probability { get; set; }


		// Constructors
		public SkillActionDescriptionCraft() { }

		public SkillActionDescriptionCraft(uint skillId = 0, uint maxSlots = 0, uint probability = 0)
		{
			SkillId = skillId;
			MaxSlots = maxSlots;
			Probability = probability;
		}

	}
}
