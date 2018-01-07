using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismSetSabotagedRequestMessage : Message
	{

		// Properties
		public uint SubAreaId { get; set; }


		// Constructors
		public PrismSetSabotagedRequestMessage() { }

		public PrismSetSabotagedRequestMessage(uint subAreaId = 0)
		{
			SubAreaId = subAreaId;
		}

	}
}
