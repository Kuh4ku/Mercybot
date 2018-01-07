using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class JobCrafterDirectoryAddMessage : Message
	{

		// Properties
		public JobCrafterDirectoryListEntry ListEntry { get; set; }


		// Constructors
		public JobCrafterDirectoryAddMessage() { }

		public JobCrafterDirectoryAddMessage(JobCrafterDirectoryListEntry listEntry = null)
		{
			ListEntry = listEntry;
		}

	}
}
