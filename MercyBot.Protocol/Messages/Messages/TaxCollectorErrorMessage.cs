using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TaxCollectorErrorMessage : Message
	{

		// Properties
		public int Reason { get; set; }


		// Constructors
		public TaxCollectorErrorMessage() { }

		public TaxCollectorErrorMessage(int reason = 0)
		{
			Reason = reason;
		}

	}
}
