using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeObjectMessage : Message
	{

		// Properties
		public bool Remote { get; set; }


		// Constructors
		public ExchangeObjectMessage() { }

		public ExchangeObjectMessage(bool remote = false)
		{
			Remote = remote;
		}

	}
}
