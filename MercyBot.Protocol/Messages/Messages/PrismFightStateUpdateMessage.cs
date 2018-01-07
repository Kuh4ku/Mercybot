using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismFightStateUpdateMessage : Message
	{

		// Properties
		public uint State { get; set; }


		// Constructors
		public PrismFightStateUpdateMessage() { }

		public PrismFightStateUpdateMessage(uint state = 0)
		{
			State = state;
		}

	}
}
