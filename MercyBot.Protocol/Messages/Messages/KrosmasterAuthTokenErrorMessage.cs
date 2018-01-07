using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class KrosmasterAuthTokenErrorMessage : Message
	{

		// Properties
		public uint Reason { get; set; }


		// Constructors
		public KrosmasterAuthTokenErrorMessage() { }

		public KrosmasterAuthTokenErrorMessage(uint reason = 0)
		{
			Reason = reason;
		}

	}
}
