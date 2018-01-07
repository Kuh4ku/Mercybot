using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectModifiedMessage : Message
	{

		// Properties
		public ObjectItem @Object { get; set; }


		// Constructors
		public ObjectModifiedMessage() { }

		public ObjectModifiedMessage(ObjectItem @object = null)
		{
			@Object = @object;
		}

	}
}
