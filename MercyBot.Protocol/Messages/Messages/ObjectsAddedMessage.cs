using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectsAddedMessage : Message
	{

		// Properties
		public List<ObjectItem> @Object { get; set; }


		// Constructors
		public ObjectsAddedMessage() { }

		public ObjectsAddedMessage(List<ObjectItem> @object = null)
		{
			@Object = @object;
		}

	}
}
