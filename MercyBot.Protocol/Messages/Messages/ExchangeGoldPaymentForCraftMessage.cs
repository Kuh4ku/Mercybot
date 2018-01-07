using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeGoldPaymentForCraftMessage : Message
	{

		// Properties
		public bool OnlySuccess { get; set; }
		public uint GoldSum { get; set; }


		// Constructors
		public ExchangeGoldPaymentForCraftMessage() { }

		public ExchangeGoldPaymentForCraftMessage(bool onlySuccess = false, uint goldSum = 0)
		{
			OnlySuccess = onlySuccess;
			GoldSum = goldSum;
		}

	}
}
