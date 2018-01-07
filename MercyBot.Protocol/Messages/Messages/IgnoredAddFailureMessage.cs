using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class IgnoredAddFailureMessage : Message
	{

		// Properties
		public uint Reason { get; set; }


		// Constructors
		public IgnoredAddFailureMessage() { }

		public IgnoredAddFailureMessage(uint reason = 0)
		{
			Reason = reason;
		}

	}
}
