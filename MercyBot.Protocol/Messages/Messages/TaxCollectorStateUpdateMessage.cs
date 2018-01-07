using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TaxCollectorStateUpdateMessage : Message
	{

		// Properties
		public int UniqueId { get; set; }
		public int State { get; set; }


		// Constructors
		public TaxCollectorStateUpdateMessage() { }

		public TaxCollectorStateUpdateMessage(int uniqueId = 0, int state = 0)
		{
			UniqueId = uniqueId;
			State = state;
		}

	}
}
