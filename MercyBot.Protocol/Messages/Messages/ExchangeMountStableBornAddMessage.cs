using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeMountStableBornAddMessage : ExchangeMountStableAddMessage
	{

		// Constructors
		public ExchangeMountStableBornAddMessage() { }

		public ExchangeMountStableBornAddMessage(MountClientData mountDescription = null)
		{
			MountDescription = mountDescription;
		}

	}
}
