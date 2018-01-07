using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismsListUpdateMessage : PrismsListMessage
	{

		// Constructors
		public PrismsListUpdateMessage() { }

		public PrismsListUpdateMessage(List<PrismSubareaEmptyInfo> prisms = null)
		{
			Prisms = prisms;
		}

	}
}
