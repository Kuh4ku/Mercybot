using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class JobAllowMultiCraftRequestSetMessage : Message
	{

		// Properties
		public bool Enabled { get; set; }


		// Constructors
		public JobAllowMultiCraftRequestSetMessage() { }

		public JobAllowMultiCraftRequestSetMessage(bool enabled = false)
		{
			Enabled = enabled;
		}

	}
}
