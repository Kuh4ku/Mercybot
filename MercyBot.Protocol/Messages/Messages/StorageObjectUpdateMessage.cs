using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class StorageObjectUpdateMessage : Message
	{

		// Properties
		public ObjectItem @Object { get; set; }


		// Constructors
		public StorageObjectUpdateMessage() { }

		public StorageObjectUpdateMessage(ObjectItem @object = null)
		{
			@Object = @object;
		}

	}
}
