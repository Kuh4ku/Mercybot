using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class StorageObjectsUpdateMessage : Message
	{

		// Properties
		public List<ObjectItem> ObjectList { get; set; }


		// Constructors
		public StorageObjectsUpdateMessage() { }

		public StorageObjectsUpdateMessage(List<ObjectItem> objectList = null)
		{
			ObjectList = objectList;
		}

	}
}
