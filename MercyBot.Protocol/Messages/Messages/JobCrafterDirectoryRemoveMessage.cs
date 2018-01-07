using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class JobCrafterDirectoryRemoveMessage : Message
	{

		// Properties
		public uint JobId { get; set; }
		public uint PlayerId { get; set; }


		// Constructors
		public JobCrafterDirectoryRemoveMessage() { }

		public JobCrafterDirectoryRemoveMessage(uint jobId = 0, uint playerId = 0)
		{
			JobId = jobId;
			PlayerId = playerId;
		}

	}
}
