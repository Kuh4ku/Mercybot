using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ObjectFoundWhileRecoltingMessage : Message
	{

		// Properties
		public uint GenericId { get; set; }
		public uint Quantity { get; set; }
		public uint RessourceGenericId { get; set; }


		// Constructors
		public ObjectFoundWhileRecoltingMessage() { }

		public ObjectFoundWhileRecoltingMessage(uint genericId = 0, uint quantity = 0, uint ressourceGenericId = 0)
		{
			GenericId = genericId;
			Quantity = quantity;
			RessourceGenericId = ressourceGenericId;
		}

	}
}
