using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class InteractiveElementWithAgeBonus : InteractiveElement
	{

		// Properties
		public int AgeBonus { get; set; }


		// Constructors
		public InteractiveElementWithAgeBonus() { }

		public InteractiveElementWithAgeBonus(uint elementId = 0, int elementTypeId = 0, int ageBonus = 0, List<InteractiveElementSkill> enabledSkills = null, List<InteractiveElementSkill> disabledSkills = null)
		{
			ElementId = elementId;
			ElementTypeId = elementTypeId;
			AgeBonus = ageBonus;
			EnabledSkills = enabledSkills;
			DisabledSkills = disabledSkills;
		}

	}
}
