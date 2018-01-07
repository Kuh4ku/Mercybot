using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeStartOkMulticraftCustomerMessage : Message
	{

		// Properties
		public uint MaxCase { get; set; }
		public uint SkillId { get; set; }
		public uint CrafterJobLevel { get; set; }


		// Constructors
		public ExchangeStartOkMulticraftCustomerMessage() { }

		public ExchangeStartOkMulticraftCustomerMessage(uint maxCase = 0, uint skillId = 0, uint crafterJobLevel = 0)
		{
			MaxCase = maxCase;
			SkillId = skillId;
			CrafterJobLevel = crafterJobLevel;
		}

	}
}
