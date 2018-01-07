using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class IdentificationFailedMessage : Message
	{

		// Properties
		public uint Reason { get; set; }


		// Constructors
		public IdentificationFailedMessage() { }

		public IdentificationFailedMessage(uint reason = 99)
		{
			Reason = reason;
		}

	}
}
