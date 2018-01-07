using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeIsReadyMessage : Message
	{

		// Properties
		public uint Id { get; set; }
		public bool Ready { get; set; }


		// Constructors
		public ExchangeIsReadyMessage() { }

		public ExchangeIsReadyMessage(uint id = 0, bool ready = false)
		{
			Id = id;
			Ready = ready;
		}

	}
}
