using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class JobLevelUpMessage : Message
	{

		// Properties
		public uint NewLevel { get; set; }
		public JobDescription JobsDescription { get; set; }


		// Constructors
		public JobLevelUpMessage() { }

		public JobLevelUpMessage(uint newLevel = 0, JobDescription jobsDescription = null)
		{
			NewLevel = newLevel;
			JobsDescription = jobsDescription;
		}

	}
}
