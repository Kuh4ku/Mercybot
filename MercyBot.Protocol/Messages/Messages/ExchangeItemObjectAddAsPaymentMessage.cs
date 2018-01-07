using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeItemObjectAddAsPaymentMessage : Message
	{

		// Properties
		public int PaymentType { get; set; }
		public bool BAdd { get; set; }
		public uint ObjectToMoveId { get; set; }
		public uint Quantity { get; set; }


		// Constructors
		public ExchangeItemObjectAddAsPaymentMessage() { }

		public ExchangeItemObjectAddAsPaymentMessage(int paymentType = 0, bool bAdd = false, uint objectToMoveId = 0, uint quantity = 0)
		{
			PaymentType = paymentType;
			BAdd = bAdd;
			ObjectToMoveId = objectToMoveId;
			Quantity = quantity;
		}

	}
}
