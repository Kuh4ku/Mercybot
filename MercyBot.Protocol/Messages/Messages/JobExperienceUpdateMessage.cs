using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class JobExperienceUpdateMessage : Message
	{

		// Properties
		public JobExperience ExperiencesUpdate { get; set; }


		// Constructors
		public JobExperienceUpdateMessage() { }

		public JobExperienceUpdateMessage(JobExperience experiencesUpdate = null)
		{
			ExperiencesUpdate = experiencesUpdate;
		}

	}
}
