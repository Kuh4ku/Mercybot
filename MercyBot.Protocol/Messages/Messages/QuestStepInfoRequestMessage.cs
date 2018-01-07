using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class QuestStepInfoRequestMessage : Message
	{

		// Properties
		public uint QuestId { get; set; }


		// Constructors
		public QuestStepInfoRequestMessage() { }

		public QuestStepInfoRequestMessage(uint questId = 0)
		{
			QuestId = questId;
		}

	}
}
