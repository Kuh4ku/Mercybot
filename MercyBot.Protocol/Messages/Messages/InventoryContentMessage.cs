using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class InventoryContentMessage : Message
	{

		// Properties
		public List<ObjectItem> Objects { get; set; }
		public uint Kamas { get; set; }


		// Constructors
		public InventoryContentMessage() { }

		public InventoryContentMessage(uint kamas = 0, List<ObjectItem> objects = null)
		{
			Kamas = kamas;
			Objects = objects;
		}

	}
}
