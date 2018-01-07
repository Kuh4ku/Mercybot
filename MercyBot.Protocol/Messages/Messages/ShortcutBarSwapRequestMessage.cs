using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ShortcutBarSwapRequestMessage : Message
	{

		// Properties
		public uint BarType { get; set; }
		public uint FirstSlot { get; set; }
		public uint SecondSlot { get; set; }


		// Constructors
		public ShortcutBarSwapRequestMessage() { }

		public ShortcutBarSwapRequestMessage(uint barType = 0, uint firstSlot = 0, uint secondSlot = 0)
		{
			BarType = barType;
			FirstSlot = firstSlot;
			SecondSlot = secondSlot;
		}

	}
}
