using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeStartedWithPodsMessage : ExchangeStartedMessage
	{

		// Properties
		public int FirstCharacterId { get; set; }
		public uint FirstCharacterCurrentWeight { get; set; }
		public uint FirstCharacterMaxWeight { get; set; }
		public int SecondCharacterId { get; set; }
		public uint SecondCharacterCurrentWeight { get; set; }
		public uint SecondCharacterMaxWeight { get; set; }


		// Constructors
		public ExchangeStartedWithPodsMessage() { }

		public ExchangeStartedWithPodsMessage(int exchangeType = 0, int firstCharacterId = 0, uint firstCharacterCurrentWeight = 0, uint firstCharacterMaxWeight = 0, int secondCharacterId = 0, uint secondCharacterCurrentWeight = 0, uint secondCharacterMaxWeight = 0)
		{
			ExchangeType = exchangeType;
			FirstCharacterId = firstCharacterId;
			FirstCharacterCurrentWeight = firstCharacterCurrentWeight;
			FirstCharacterMaxWeight = firstCharacterMaxWeight;
			SecondCharacterId = secondCharacterId;
			SecondCharacterCurrentWeight = secondCharacterCurrentWeight;
			SecondCharacterMaxWeight = secondCharacterMaxWeight;
		}

	}
}
