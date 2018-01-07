using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeBidHouseGenericItemRemovedMessage : Message
	{

		// Properties
		public int ObjGenericId { get; set; }


		// Constructors
		public ExchangeBidHouseGenericItemRemovedMessage() { }

		public ExchangeBidHouseGenericItemRemovedMessage(int objGenericId = 0)
		{
			ObjGenericId = objGenericId;
		}

	}
}
