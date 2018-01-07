using System.Collections.Generic;
using MercyBot.Protocol.Types;
using MercyBot.Protocol.Converters;
using Newtonsoft.Json;

namespace MercyBot.Protocol.Types
{
	public class JobDescription
	{

		// Properties
        [JsonConverter(typeof(TypedPropertyConverter))]
		public List<SkillActionDescription> Skills { get; set; }
		public uint JobId { get; set; }


		// Constructors
		public JobDescription() { }

		public JobDescription(uint jobId = 0, List<SkillActionDescription> skills = null)
		{
			JobId = jobId;
			Skills = skills;
		}

	}
}
