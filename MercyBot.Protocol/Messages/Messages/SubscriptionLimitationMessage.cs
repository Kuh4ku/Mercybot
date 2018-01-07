using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class SubscriptionLimitationMessage : Message
	{

		// Properties
		public uint Reason { get; set; }


		// Constructors
		public SubscriptionLimitationMessage() { }

		public SubscriptionLimitationMessage(uint reason = 0)
		{
			Reason = reason;
		}

	}
}
