using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Types
{
	public class Shortcut
	{

		// Properties
		public uint Slot { get; set; }


		// Constructors
		public Shortcut() { }

		public Shortcut(uint slot = 0)
		{
			Slot = slot;
		}

	}
}
