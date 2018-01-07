using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class JobCrafterDirectorySettingsMessage : Message
	{

		// Properties
		public List<JobCrafterDirectorySettings> CraftersSettings { get; set; }


		// Constructors
		public JobCrafterDirectorySettingsMessage() { }

		public JobCrafterDirectorySettingsMessage(List<JobCrafterDirectorySettings> craftersSettings = null)
		{
			CraftersSettings = craftersSettings;
		}

	}
}
