using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectFeedMessage : Message
	{

		// Properties
		public uint ObjectUID { get; set; }
		public uint FoodUID { get; set; }
		public uint FoodQuantity { get; set; }


		// Constructors
		public ObjectFeedMessage() { }

		public ObjectFeedMessage(uint objectUID = 0, uint foodUID = 0, uint foodQuantity = 0)
		{
			ObjectUID = objectUID;
			FoodUID = foodUID;
			FoodQuantity = foodQuantity;
		}

	}
}
