using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeRequestOnTaxCollectorMessage : Message
	{

		// Properties
		public int TaxCollectorId { get; set; }


		// Constructors
		public ExchangeRequestOnTaxCollectorMessage() { }

		public ExchangeRequestOnTaxCollectorMessage(int taxCollectorId = 0)
		{
			TaxCollectorId = taxCollectorId;
		}

	}
}
