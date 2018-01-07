using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class QuestStepStartedMessage : Message
	{

		// Properties
		public uint QuestId { get; set; }
		public uint StepId { get; set; }


		// Constructors
		public QuestStepStartedMessage() { }

		public QuestStepStartedMessage(uint questId = 0, uint stepId = 0)
		{
			QuestId = questId;
			StepId = stepId;
		}

	}
}
