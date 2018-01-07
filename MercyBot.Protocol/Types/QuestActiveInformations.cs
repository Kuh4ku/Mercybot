using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class QuestActiveInformations
	{

		// Properties
		public uint QuestId { get; set; }


		// Constructors
		public QuestActiveInformations() { }

		public QuestActiveInformations(uint questId = 0)
		{
			QuestId = questId;
		}

	}
}
