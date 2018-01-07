using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismSetSabotagedRefusedMessage : Message
	{

		// Properties
		public uint SubAreaId { get; set; }
		public int Reason { get; set; }


		// Constructors
		public PrismSetSabotagedRefusedMessage() { }

		public PrismSetSabotagedRefusedMessage(uint subAreaId = 0, int reason = 0)
		{
			SubAreaId = subAreaId;
			Reason = reason;
		}

	}
}
