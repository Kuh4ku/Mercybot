using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class JobExperienceMultiUpdateMessage : Message
	{

		// Properties
		public List<JobExperience> ExperiencesUpdate { get; set; }


		// Constructors
		public JobExperienceMultiUpdateMessage() { }

		public JobExperienceMultiUpdateMessage(List<JobExperience> experiencesUpdate = null)
		{
			ExperiencesUpdate = experiencesUpdate;
		}

	}
}
