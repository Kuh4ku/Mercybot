using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeTypesExchangerDescriptionForUserMessage : Message
	{

		// Properties
		public List<uint> TypeDescription { get; set; }


		// Constructors
		public ExchangeTypesExchangerDescriptionForUserMessage() { }

		public ExchangeTypesExchangerDescriptionForUserMessage(List<uint> typeDescription = null)
		{
			TypeDescription = typeDescription;
		}

	}
}
