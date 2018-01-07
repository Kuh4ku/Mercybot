using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismFightRemovedMessage : Message
	{

		// Properties
		public uint SubAreaId { get; set; }


		// Constructors
		public PrismFightRemovedMessage() { }

		public PrismFightRemovedMessage(uint subAreaId = 0)
		{
			SubAreaId = subAreaId;
		}

	}
}
