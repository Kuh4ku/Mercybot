using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class JobCrafterDirectoryEntryJobInfo
	{

		// Properties
		public uint JobId { get; set; }
		public uint JobLevel { get; set; }
		public uint UserDefinedParams { get; set; }
		public uint MinSlots { get; set; }


		// Constructors
		public JobCrafterDirectoryEntryJobInfo() { }

		public JobCrafterDirectoryEntryJobInfo(uint jobId = 0, uint jobLevel = 0, uint userDefinedParams = 0, uint minSlots = 0)
		{
			JobId = jobId;
			JobLevel = jobLevel;
			UserDefinedParams = userDefinedParams;
			MinSlots = minSlots;
		}

	}
}
