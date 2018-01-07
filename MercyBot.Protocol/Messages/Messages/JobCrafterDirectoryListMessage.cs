using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class JobCrafterDirectoryListMessage : Message
	{

		// Properties
		public List<JobCrafterDirectoryListEntry> ListEntries { get; set; }


		// Constructors
		public JobCrafterDirectoryListMessage() { }

		public JobCrafterDirectoryListMessage(List<JobCrafterDirectoryListEntry> listEntries = null)
		{
			ListEntries = listEntries;
		}

	}
}
