using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class InteractiveUseEndedMessage : Message
	{

		// Properties
		public uint ElemId { get; set; }
		public uint SkillId { get; set; }


		// Constructors
		public InteractiveUseEndedMessage() { }

		public InteractiveUseEndedMessage(uint elemId = 0, uint skillId = 0)
		{
			ElemId = elemId;
			SkillId = skillId;
		}

	}
}
