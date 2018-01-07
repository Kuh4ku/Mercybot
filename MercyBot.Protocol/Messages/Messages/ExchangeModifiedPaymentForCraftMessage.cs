using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeModifiedPaymentForCraftMessage : Message
	{

		// Properties
		public bool OnlySuccess { get; set; }
		public ObjectItemNotInContainer @Object { get; set; }


		// Constructors
		public ExchangeModifiedPaymentForCraftMessage() { }

		public ExchangeModifiedPaymentForCraftMessage(bool onlySuccess = false, ObjectItemNotInContainer @object = null)
		{
			OnlySuccess = onlySuccess;
			@Object = @object;
		}

	}
}
