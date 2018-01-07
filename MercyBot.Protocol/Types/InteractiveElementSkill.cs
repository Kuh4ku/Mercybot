using Newtonsoft.Json;

namespace MercyBot.Protocol.Types
{
    public class InteractiveElementSkill
	{

		// Properties
		public uint SkillId { get; set; }
		public uint SkillInstanceUid { get; set; }
        [JsonProperty("_name")]
        public string Name { get; set; }
        [JsonProperty("_parentJobName")]
        public string ParentName { get; set; }
        [JsonProperty("_levelMin")]
        public byte LevelMin { get; set; }
        [JsonProperty("_parentJobId")]
        public byte ParentJobId { get; set; }


        // Constructors
        public InteractiveElementSkill() { }

		public InteractiveElementSkill(uint skillId = 0, uint skillInstanceUid = 0)
		{
			SkillId = skillId;
			SkillInstanceUid = skillInstanceUid;
		}

	}
}
