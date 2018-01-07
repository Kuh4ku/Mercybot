using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectAddedMessage : Message
	{

		// Properties
		public ObjectItem @Object { get; set; }


		// Constructors
		public ObjectAddedMessage() { }

		public ObjectAddedMessage(ObjectItem @object = null)
		{
			@Object = @object;
		}

	}
}
