using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class QuestStepValidatedMessage : Message
	{

		// Properties
		public uint QuestId { get; set; }
		public uint StepId { get; set; }


		// Constructors
		public QuestStepValidatedMessage() { }

		public QuestStepValidatedMessage(uint questId = 0, uint stepId = 0)
		{
			QuestId = questId;
			StepId = stepId;
		}

	}
}
