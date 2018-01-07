using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeStartedWithStorageMessage : ExchangeStartedMessage
	{

		// Properties
		public uint StorageMaxSlot { get; set; }


		// Constructors
		public ExchangeStartedWithStorageMessage() { }

		public ExchangeStartedWithStorageMessage(int exchangeType = 0, uint storageMaxSlot = 0)
		{
			ExchangeType = exchangeType;
			StorageMaxSlot = storageMaxSlot;
		}

	}
}
