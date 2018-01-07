using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ShortcutBarSwapErrorMessage : Message
	{

		// Properties
		public uint Error { get; set; }


		// Constructors
		public ShortcutBarSwapErrorMessage() { }

		public ShortcutBarSwapErrorMessage(uint error = 0)
		{
			Error = error;
		}

	}
}
