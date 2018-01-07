using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeReplyTaxVendorMessage : Message
	{

		// Properties
		public uint ObjectValue { get; set; }
		public uint TotalTaxValue { get; set; }


		// Constructors
		public ExchangeReplyTaxVendorMessage() { }

		public ExchangeReplyTaxVendorMessage(uint objectValue = 0, uint totalTaxValue = 0)
		{
			ObjectValue = objectValue;
			TotalTaxValue = totalTaxValue;
		}

	}
}
