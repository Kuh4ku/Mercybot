using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeObjectRemovedFromBagMessage : ExchangeObjectMessage
	{

		// Properties
		public uint ObjectUID { get; set; }


		// Constructors
		public ExchangeObjectRemovedFromBagMessage() { }

		public ExchangeObjectRemovedFromBagMessage(bool remote = false, uint objectUID = 0)
		{
			Remote = remote;
			ObjectUID = objectUID;
		}

	}
}
