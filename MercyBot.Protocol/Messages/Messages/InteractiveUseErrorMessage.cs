using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class InteractiveUseErrorMessage : Message
	{

		// Properties
		public uint ElemId { get; set; }
		public uint SkillInstanceUid { get; set; }


		// Constructors
		public InteractiveUseErrorMessage() { }

		public InteractiveUseErrorMessage(uint elemId = 0, uint skillInstanceUid = 0)
		{
			ElemId = elemId;
			SkillInstanceUid = skillInstanceUid;
		}

	}
}
