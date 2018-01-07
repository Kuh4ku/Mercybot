using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectsQuantityMessage : Message
	{

		// Properties
		public List<ObjectItemQuantity> ObjectsUIDAndQty { get; set; }


		// Constructors
		public ObjectsQuantityMessage() { }

		public ObjectsQuantityMessage(List<ObjectItemQuantity> objectsUIDAndQty = null)
		{
			ObjectsUIDAndQty = objectsUIDAndQty;
		}

	}
}
