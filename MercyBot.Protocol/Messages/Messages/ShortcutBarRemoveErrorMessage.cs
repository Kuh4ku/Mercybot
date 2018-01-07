using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ShortcutBarRemoveErrorMessage : Message
	{

		// Properties
		public uint Error { get; set; }


		// Constructors
		public ShortcutBarRemoveErrorMessage() { }

		public ShortcutBarRemoveErrorMessage(uint error = 0)
		{
			Error = error;
		}

	}
}
