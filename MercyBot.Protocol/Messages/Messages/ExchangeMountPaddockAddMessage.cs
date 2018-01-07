using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeMountPaddockAddMessage : Message
	{

		// Properties
		public MountClientData MountDescription { get; set; }


		// Constructors
		public ExchangeMountPaddockAddMessage() { }

		public ExchangeMountPaddockAddMessage(MountClientData mountDescription = null)
		{
			MountDescription = mountDescription;
		}

	}
}
