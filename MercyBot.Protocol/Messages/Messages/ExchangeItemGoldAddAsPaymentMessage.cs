using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeItemGoldAddAsPaymentMessage : Message
	{

		// Properties
		public int PaymentType { get; set; }
		public uint Quantity { get; set; }


		// Constructors
		public ExchangeItemGoldAddAsPaymentMessage() { }

		public ExchangeItemGoldAddAsPaymentMessage(int paymentType = 0, uint quantity = 0)
		{
			PaymentType = paymentType;
			Quantity = quantity;
		}

	}
}
