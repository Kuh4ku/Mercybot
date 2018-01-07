using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeClearPaymentForCraftMessage : Message
	{

		// Properties
		public int PaymentType { get; set; }


		// Constructors
		public ExchangeClearPaymentForCraftMessage() { }

		public ExchangeClearPaymentForCraftMessage(int paymentType = 0)
		{
			PaymentType = paymentType;
		}

	}
}
