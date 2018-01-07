using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeKamaModifiedMessage : ExchangeObjectMessage
	{

		// Properties
		public uint Quantity { get; set; }


		// Constructors
		public ExchangeKamaModifiedMessage() { }

		public ExchangeKamaModifiedMessage(bool remote = false, uint quantity = 0)
		{
			Remote = remote;
			Quantity = quantity;
		}

	}
}
