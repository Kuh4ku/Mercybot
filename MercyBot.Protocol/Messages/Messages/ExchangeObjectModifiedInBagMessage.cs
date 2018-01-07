using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeObjectModifiedInBagMessage : ExchangeObjectMessage
	{

		// Properties
		public ObjectItem @Object { get; set; }


		// Constructors
		public ExchangeObjectModifiedInBagMessage() { }

		public ExchangeObjectModifiedInBagMessage(bool remote = false, ObjectItem @object = null)
		{
			Remote = remote;
			@Object = @object;
		}

	}
}
