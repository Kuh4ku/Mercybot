using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeStartOkMulticraftCrafterMessage : Message
	{

		// Properties
		public uint MaxCase { get; set; }
		public uint SkillId { get; set; }


		// Constructors
		public ExchangeStartOkMulticraftCrafterMessage() { }

		public ExchangeStartOkMulticraftCrafterMessage(uint maxCase = 0, uint skillId = 0)
		{
			MaxCase = maxCase;
			SkillId = skillId;
		}

	}
}
