using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeObjectAddedMessage : ExchangeObjectMessage
	{

		// Properties
		public ObjectItem @Object { get; set; }


		// Constructors
		public ExchangeObjectAddedMessage() { }

		public ExchangeObjectAddedMessage(bool remote = false, ObjectItem @object = null)
		{
			Remote = remote;
			@Object = @object;
		}

	}
}
