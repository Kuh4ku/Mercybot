using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ObjectItemQuantity : Item
	{

		// Properties
		public uint ObjectUID { get; set; }
		public uint Quantity { get; set; }


		// Constructors
		public ObjectItemQuantity() { }

		public ObjectItemQuantity(uint objectUID = 0, uint quantity = 0)
		{
			ObjectUID = objectUID;
			Quantity = quantity;
		}

	}
}
