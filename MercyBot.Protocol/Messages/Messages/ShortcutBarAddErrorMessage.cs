using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ShortcutBarAddErrorMessage : Message
	{

		// Properties
		public uint Error { get; set; }


		// Constructors
		public ShortcutBarAddErrorMessage() { }

		public ShortcutBarAddErrorMessage(uint error = 0)
		{
			Error = error;
		}

	}
}
