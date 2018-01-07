using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class QuestObjectiveInformations
	{

		// Properties
		public List<string> DialogParams { get; set; }
		public uint ObjectiveId { get; set; }
		public bool ObjectiveStatus { get; set; }


		// Constructors
		public QuestObjectiveInformations() { }

		public QuestObjectiveInformations(uint objectiveId = 0, bool objectiveStatus = false, List<string> dialogParams = null)
		{
			ObjectiveId = objectiveId;
			ObjectiveStatus = objectiveStatus;
			DialogParams = dialogParams;
		}

	}
}
