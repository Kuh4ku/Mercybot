using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GoldAddedMessage : Message
	{

		// Properties
		public GoldItem Gold { get; set; }


		// Constructors
		public GoldAddedMessage() { }

		public GoldAddedMessage(GoldItem gold = null)
		{
			Gold = gold;
		}

	}
}
