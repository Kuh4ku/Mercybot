using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class JobCrafterDirectorySettings
	{

		// Properties
		public uint JobId { get; set; }
		public uint MinSlot { get; set; }
		public uint UserDefinedParams { get; set; }


		// Constructors
		public JobCrafterDirectorySettings() { }

		public JobCrafterDirectorySettings(uint jobId = 0, uint minSlot = 0, uint userDefinedParams = 0)
		{
			JobId = jobId;
			MinSlot = minSlot;
			UserDefinedParams = userDefinedParams;
		}

	}
}
