using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class QuestListMessage : Message
	{

		// Properties
		public List<uint> FinishedQuestsIds { get; set; }
		public List<uint> FinishedQuestsCounts { get; set; }
		public List<QuestActiveInformations> ActiveQuests { get; set; }


		// Constructors
		public QuestListMessage() { }

		public QuestListMessage(List<uint> finishedQuestsIds = null, List<uint> finishedQuestsCounts = null, List<QuestActiveInformations> activeQuests = null)
		{
			FinishedQuestsIds = finishedQuestsIds;
			FinishedQuestsCounts = finishedQuestsCounts;
			ActiveQuests = activeQuests;
		}

	}
}
