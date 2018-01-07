using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class JobCrafterDirectoryEntryMessage : Message
	{

		// Properties
		public List<JobCrafterDirectoryEntryJobInfo> JobInfoList { get; set; }
		public JobCrafterDirectoryEntryPlayerInfo PlayerInfo { get; set; }
		public EntityLook PlayerLook { get; set; }


		// Constructors
		public JobCrafterDirectoryEntryMessage() { }

		public JobCrafterDirectoryEntryMessage(JobCrafterDirectoryEntryPlayerInfo playerInfo = null, EntityLook playerLook = null, List<JobCrafterDirectoryEntryJobInfo> jobInfoList = null)
		{
			PlayerInfo = playerInfo;
			PlayerLook = playerLook;
			JobInfoList = jobInfoList;
		}

	}
}
