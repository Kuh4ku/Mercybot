using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectDropMessage : Message
	{

		// Properties
		public uint ObjectUID { get; set; }
		public uint Quantity { get; set; }


		// Constructors
		public ObjectDropMessage() { }

		public ObjectDropMessage(uint objectUID = 0, uint quantity = 0)
		{
			ObjectUID = objectUID;
			Quantity = quantity;
		}

	}
}
