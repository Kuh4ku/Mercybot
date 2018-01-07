using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeOnHumanVendorRequestMessage : Message
	{

		// Properties
		public uint HumanVendorId { get; set; }
		public uint HumanVendorCell { get; set; }


		// Constructors
		public ExchangeOnHumanVendorRequestMessage() { }

		public ExchangeOnHumanVendorRequestMessage(uint humanVendorId = 0, uint humanVendorCell = 0)
		{
			HumanVendorId = humanVendorId;
			HumanVendorCell = humanVendorCell;
		}

	}
}
