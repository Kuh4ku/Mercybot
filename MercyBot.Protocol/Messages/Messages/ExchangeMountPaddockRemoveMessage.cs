using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ExchangeMountPaddockRemoveMessage : Message
	{

		// Properties
		public double MountId { get; set; }


		// Constructors
		public ExchangeMountPaddockRemoveMessage() { }

		public ExchangeMountPaddockRemoveMessage(double mountId = 0)
		{
			MountId = mountId;
		}

	}
}
