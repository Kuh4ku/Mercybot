using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class InteractiveUseRequestMessage : Message
	{

		// Properties
		public uint ElemId { get; set; }
		public uint SkillInstanceUid { get; set; }


		// Constructors
		public InteractiveUseRequestMessage() { }

		public InteractiveUseRequestMessage(uint elemId = 0, uint skillInstanceUid = 0)
		{
			ElemId = elemId;
			SkillInstanceUid = skillInstanceUid;
		}

	}
}
