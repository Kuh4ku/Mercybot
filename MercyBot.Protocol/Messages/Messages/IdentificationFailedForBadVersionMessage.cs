using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class IdentificationFailedForBadVersionMessage : IdentificationFailedMessage
	{

		// Constructors
		public IdentificationFailedForBadVersionMessage() { }

		public IdentificationFailedForBadVersionMessage(uint reason = 99)
		{
			Reason = reason;
		}

	}
}
