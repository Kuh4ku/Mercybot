using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeObjectUseInWorkshopMessage : Message
	{

		// Properties
		public uint ObjectUID { get; set; }
		public int Quantity { get; set; }


		// Constructors
		public ExchangeObjectUseInWorkshopMessage() { }

		public ExchangeObjectUseInWorkshopMessage(uint objectUID = 0, int quantity = 0)
		{
			ObjectUID = objectUID;
			Quantity = quantity;
		}

	}
}
