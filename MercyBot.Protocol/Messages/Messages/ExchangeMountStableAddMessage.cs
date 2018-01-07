using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeMountStableAddMessage : Message
	{

		// Properties
		public MountClientData MountDescription { get; set; }


		// Constructors
		public ExchangeMountStableAddMessage() { }

		public ExchangeMountStableAddMessage(MountClientData mountDescription = null)
		{
			MountDescription = mountDescription;
		}

	}
}
