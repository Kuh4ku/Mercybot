using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class JobAllowMultiCraftRequestMessage : Message
	{

		// Properties
		public bool Enabled { get; set; }


		// Constructors
		public JobAllowMultiCraftRequestMessage() { }

		public JobAllowMultiCraftRequestMessage(bool enabled = false)
		{
			Enabled = enabled;
		}

	}
}
