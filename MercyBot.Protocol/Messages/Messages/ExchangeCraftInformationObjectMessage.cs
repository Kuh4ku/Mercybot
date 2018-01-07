using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeCraftInformationObjectMessage : ExchangeCraftResultWithObjectIdMessage
	{

		// Properties
		public uint PlayerId { get; set; }


		// Constructors
		public ExchangeCraftInformationObjectMessage() { }

		public ExchangeCraftInformationObjectMessage(uint craftResult = 0, uint objectGenericId = 0, uint playerId = 0)
		{
			CraftResult = craftResult;
			ObjectGenericId = objectGenericId;
			PlayerId = playerId;
		}

	}
}
