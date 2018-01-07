using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismFightSwapRequestMessage : Message
	{

		// Properties
		public uint SubAreaId { get; set; }
		public uint TargetId { get; set; }


		// Constructors
		public PrismFightSwapRequestMessage() { }

		public PrismFightSwapRequestMessage(uint subAreaId = 0, uint targetId = 0)
		{
			SubAreaId = subAreaId;
			TargetId = targetId;
		}

	}
}
