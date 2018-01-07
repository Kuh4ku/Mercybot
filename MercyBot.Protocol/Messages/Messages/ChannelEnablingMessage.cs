using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChannelEnablingMessage : Message
	{

		// Properties
		public uint Channel { get; set; }
		public bool Enable { get; set; }


		// Constructors
		public ChannelEnablingMessage() { }

		public ChannelEnablingMessage(uint channel = 0, bool enable = false)
		{
			Channel = channel;
			Enable = enable;
		}

	}
}
