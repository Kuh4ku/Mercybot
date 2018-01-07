using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PrismInfoInValidMessage : Message
	{

		// Properties
		public uint Reason { get; set; }


		// Constructors
		public PrismInfoInValidMessage() { }

		public PrismInfoInValidMessage(uint reason = 0)
		{
			Reason = reason;
		}

	}
}
