using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectUseMultipleMessage : ObjectUseMessage
	{

		// Properties
		public uint Quantity { get; set; }


		// Constructors
		public ObjectUseMultipleMessage() { }

		public ObjectUseMultipleMessage(uint objectUID = 0, uint quantity = 0)
		{
			ObjectUID = objectUID;
			Quantity = quantity;
		}

	}
}
