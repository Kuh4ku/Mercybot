using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class JobListedUpdateMessage : Message
	{

		// Properties
		public bool AddedOrDeleted { get; set; }
		public uint JobId { get; set; }


		// Constructors
		public JobListedUpdateMessage() { }

		public JobListedUpdateMessage(bool addedOrDeleted = false, uint jobId = 0)
		{
			AddedOrDeleted = addedOrDeleted;
			JobId = jobId;
		}

	}
}
