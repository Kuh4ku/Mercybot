using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class JobCrafterDirectoryListEntry
	{

		// Properties
		public JobCrafterDirectoryEntryPlayerInfo PlayerInfo { get; set; }
		public JobCrafterDirectoryEntryJobInfo JobInfo { get; set; }


		// Constructors
		public JobCrafterDirectoryListEntry() { }

		public JobCrafterDirectoryListEntry(JobCrafterDirectoryEntryPlayerInfo playerInfo = null, JobCrafterDirectoryEntryJobInfo jobInfo = null)
		{
			PlayerInfo = playerInfo;
			JobInfo = jobInfo;
		}

	}
}
