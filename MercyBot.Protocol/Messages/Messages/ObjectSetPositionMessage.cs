using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectSetPositionMessage : Message
	{

		// Properties
		public uint ObjectUID { get; set; }
		public uint Position { get; set; }
		public uint Quantity { get; set; }


		// Constructors
		public ObjectSetPositionMessage() { }

		public ObjectSetPositionMessage(uint objectUID = 0, uint position = 63, uint quantity = 0)
		{
			ObjectUID = objectUID;
			Position = position;
			Quantity = quantity;
		}

	}
}
