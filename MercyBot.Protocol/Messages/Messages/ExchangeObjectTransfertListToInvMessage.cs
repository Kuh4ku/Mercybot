using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeObjectTransfertListToInvMessage : Message
	{

		// Properties
		public List<uint> Ids { get; set; }


		// Constructors
		public ExchangeObjectTransfertListToInvMessage() { }

		public ExchangeObjectTransfertListToInvMessage(List<uint> ids = null)
		{
			Ids = ids;
		}

	}
}
