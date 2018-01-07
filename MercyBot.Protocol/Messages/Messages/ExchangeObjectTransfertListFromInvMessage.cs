using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeObjectTransfertListFromInvMessage : Message
	{

		// Properties
		public List<uint> Ids { get; set; }


		// Constructors
		public ExchangeObjectTransfertListFromInvMessage() { }

		public ExchangeObjectTransfertListFromInvMessage(List<uint> ids = null)
		{
			Ids = ids;
		}

	}
}
