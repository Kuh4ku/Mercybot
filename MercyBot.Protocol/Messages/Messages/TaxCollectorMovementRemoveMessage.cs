using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TaxCollectorMovementRemoveMessage : Message
	{

		// Properties
		public int CollectorId { get; set; }


		// Constructors
		public TaxCollectorMovementRemoveMessage() { }

		public TaxCollectorMovementRemoveMessage(int collectorId = 0)
		{
			CollectorId = collectorId;
		}

	}
}
