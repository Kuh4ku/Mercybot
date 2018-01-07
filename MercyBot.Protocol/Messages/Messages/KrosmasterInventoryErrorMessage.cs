using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class KrosmasterInventoryErrorMessage : Message
	{

		// Properties
		public uint Reason { get; set; }


		// Constructors
		public KrosmasterInventoryErrorMessage() { }

		public KrosmasterInventoryErrorMessage(uint reason = 0)
		{
			Reason = reason;
		}

	}
}
