using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class QuestActiveDetailedInformations : QuestActiveInformations
	{

		// Properties
		public List<QuestObjectiveInformations> Objectives { get; set; }
		public uint StepId { get; set; }


		// Constructors
		public QuestActiveDetailedInformations() { }

		public QuestActiveDetailedInformations(uint questId = 0, uint stepId = 0, List<QuestObjectiveInformations> objectives = null)
		{
			QuestId = questId;
			StepId = stepId;
			Objectives = objectives;
		}

	}
}
