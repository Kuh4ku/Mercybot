using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class JobDescriptionMessage : Message
	{

		// Properties
		public List<JobDescription> JobsDescription { get; set; }


		// Constructors
		public JobDescriptionMessage() { }

		public JobDescriptionMessage(List<JobDescription> jobsDescription = null)
		{
			JobsDescription = jobsDescription;
		}

	}
}
