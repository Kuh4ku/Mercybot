using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class QuestObjectiveValidationMessage : Message
	{

		// Properties
		public uint QuestId { get; set; }
		public uint ObjectiveId { get; set; }


		// Constructors
		public QuestObjectiveValidationMessage() { }

		public QuestObjectiveValidationMessage(uint questId = 0, uint objectiveId = 0)
		{
			QuestId = questId;
			ObjectiveId = objectiveId;
		}

	}
}
