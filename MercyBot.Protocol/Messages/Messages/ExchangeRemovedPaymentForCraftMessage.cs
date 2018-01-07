using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeRemovedPaymentForCraftMessage : Message
	{

		// Properties
		public bool OnlySuccess { get; set; }
		public uint ObjectUID { get; set; }


		// Constructors
		public ExchangeRemovedPaymentForCraftMessage() { }

		public ExchangeRemovedPaymentForCraftMessage(bool onlySuccess = false, uint objectUID = 0)
		{
			OnlySuccess = onlySuccess;
			ObjectUID = objectUID;
		}

	}
}
