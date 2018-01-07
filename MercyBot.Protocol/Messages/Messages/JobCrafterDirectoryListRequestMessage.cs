using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class JobCrafterDirectoryListRequestMessage : Message
	{

		// Properties
		public uint JobId { get; set; }


		// Constructors
		public JobCrafterDirectoryListRequestMessage() { }

		public JobCrafterDirectoryListRequestMessage(uint jobId = 0)
		{
			JobId = jobId;
		}

	}
}
