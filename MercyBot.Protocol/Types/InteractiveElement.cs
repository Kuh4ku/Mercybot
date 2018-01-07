using System.Collections.Generic;
using Newtonsoft.Json;

namespace MercyBot.Protocol.Types
{
    public class InteractiveElement
	{

		// Properties
		public List<InteractiveElementSkill> EnabledSkills { get; set; }
		public List<InteractiveElementSkill> DisabledSkills { get; set; }
		public uint ElementId { get; set; }
		public int ElementTypeId { get; set; }
        [JsonProperty("_name")]
        public string Name { get; set; }


		// Constructors
		public InteractiveElement() { }

		public InteractiveElement(uint elementId = 0, int elementTypeId = 0, List<InteractiveElementSkill> enabledSkills = null, List<InteractiveElementSkill> disabledSkills = null)
		{
			ElementId = elementId;
			ElementTypeId = elementTypeId;
			EnabledSkills = enabledSkills;
			DisabledSkills = disabledSkills;
		}

	}
}
