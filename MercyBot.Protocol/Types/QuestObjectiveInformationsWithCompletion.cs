using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class QuestObjectiveInformationsWithCompletion : QuestObjectiveInformations
	{

		// Properties
		public uint CurCompletion { get; set; }
		public uint MaxCompletion { get; set; }


		// Constructors
		public QuestObjectiveInformationsWithCompletion() { }

		public QuestObjectiveInformationsWithCompletion(uint objectiveId = 0, bool objectiveStatus = false, uint curCompletion = 0, uint maxCompletion = 0, List<string> dialogParams = null)
		{
			ObjectiveId = objectiveId;
			ObjectiveStatus = objectiveStatus;
			CurCompletion = curCompletion;
			MaxCompletion = maxCompletion;
			DialogParams = dialogParams;
		}

	}
}
