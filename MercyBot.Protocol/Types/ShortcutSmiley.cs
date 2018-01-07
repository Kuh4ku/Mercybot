using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class ShortcutSmiley : Shortcut
	{

		// Properties
		public uint SmileyId { get; set; }


		// Constructors
		public ShortcutSmiley() { }

		public ShortcutSmiley(uint slot = 0, uint smileyId = 0)
		{
			Slot = slot;
			SmileyId = smileyId;
		}

	}
}
