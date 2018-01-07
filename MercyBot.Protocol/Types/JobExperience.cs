using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class JobExperience
	{

		// Properties
		public uint JobId { get; set; }
		public uint JobLevel { get; set; }
		public double JobXP { get; set; }
		public double JobXpLevelFloor { get; set; }
		public double JobXpNextLevelFloor { get; set; }


		// Constructors
		public JobExperience() { }

		public JobExperience(uint jobId = 0, uint jobLevel = 0, double jobXP = 0, double jobXpLevelFloor = 0, double jobXpNextLevelFloor = 0)
		{
			JobId = jobId;
			JobLevel = jobLevel;
			JobXP = jobXP;
			JobXpLevelFloor = jobXpLevelFloor;
			JobXpNextLevelFloor = jobXpNextLevelFloor;
		}

	}
}
