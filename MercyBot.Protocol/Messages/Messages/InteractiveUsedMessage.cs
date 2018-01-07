using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class InteractiveUsedMessage : Message
	{

		// Properties
		public uint EntityId { get; set; }
		public uint ElemId { get; set; }
		public uint SkillId { get; set; }
		public uint Duration { get; set; }


		// Constructors
		public InteractiveUsedMessage() { }

		public InteractiveUsedMessage(uint entityId = 0, uint elemId = 0, uint skillId = 0, uint duration = 0)
		{
			EntityId = entityId;
			ElemId = elemId;
			SkillId = skillId;
			Duration = duration;
		}

	}
}
