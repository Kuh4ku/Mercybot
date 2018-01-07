using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class JobUnlearntMessage : Message
	{

		// Properties
		public uint JobId { get; set; }


		// Constructors
		public JobUnlearntMessage() { }

		public JobUnlearntMessage(uint jobId = 0)
		{
			JobId = jobId;
		}

	}
}
