using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ShortcutObject : Shortcut
	{

		// Constructors
		public ShortcutObject() { }

		public ShortcutObject(uint slot = 0)
		{
			Slot = slot;
		}

	}
}
