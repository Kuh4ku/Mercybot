using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AchievementDetailedListRequestMessage : Message
	{

		// Properties
		public uint CategoryId { get; set; }


		// Constructors
		public AchievementDetailedListRequestMessage() { }

		public AchievementDetailedListRequestMessage(uint categoryId = 0)
		{
			CategoryId = categoryId;
		}

	}
}
