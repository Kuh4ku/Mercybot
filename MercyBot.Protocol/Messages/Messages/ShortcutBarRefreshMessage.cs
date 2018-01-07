using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ShortcutBarRefreshMessage : Message
	{

		// Properties
		public uint BarType { get; set; }
		public Shortcut Shortcut { get; set; }


		// Constructors
		public ShortcutBarRefreshMessage() { }

		public ShortcutBarRefreshMessage(uint barType = 0, Shortcut shortcut = null)
		{
			BarType = barType;
			Shortcut = shortcut;
		}

	}
}
