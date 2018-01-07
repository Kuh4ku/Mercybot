using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeBidHouseBuyResultMessage : Message
	{

		// Properties
		public uint Uid { get; set; }
		public bool Bought { get; set; }


		// Constructors
		public ExchangeBidHouseBuyResultMessage() { }

		public ExchangeBidHouseBuyResultMessage(uint uid = 0, bool bought = false)
		{
			Uid = uid;
			Bought = bought;
		}

	}
}
