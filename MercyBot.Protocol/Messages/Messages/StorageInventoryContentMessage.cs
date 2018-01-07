using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class StorageInventoryContentMessage : InventoryContentMessage
	{

		// Constructors
		public StorageInventoryContentMessage() { }

		public StorageInventoryContentMessage(uint kamas = 0, List<ObjectItem> objects = null)
		{
			Kamas = kamas;
			Objects = objects;
		}

	}
}
