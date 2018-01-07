using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeStartOkCraftWithInformationMessage : ExchangeStartOkCraftMessage
	{

		// Properties
		public uint NbCase { get; set; }
		public uint SkillId { get; set; }


		// Constructors
		public ExchangeStartOkCraftWithInformationMessage() { }

		public ExchangeStartOkCraftWithInformationMessage(uint nbCase = 0, uint skillId = 0)
		{
			NbCase = nbCase;
			SkillId = skillId;
		}

	}
}
