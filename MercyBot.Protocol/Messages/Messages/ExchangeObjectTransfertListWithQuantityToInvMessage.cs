using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeObjectTransfertListWithQuantityToInvMessage : Message
	{

		// Properties
		public List<uint> Ids { get; set; }
		public List<uint> Qtys { get; set; }


		// Constructors
		public ExchangeObjectTransfertListWithQuantityToInvMessage() { }

		public ExchangeObjectTransfertListWithQuantityToInvMessage(List<uint> ids = null, List<uint> qtys = null)
		{
			Ids = ids;
			Qtys = qtys;
		}

	}
}
