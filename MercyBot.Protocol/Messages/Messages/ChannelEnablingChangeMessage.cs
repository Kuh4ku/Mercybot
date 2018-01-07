using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ChannelEnablingChangeMessage : Message
	{

		// Properties
		public uint Channel { get; set; }
		public bool Enable { get; set; }


		// Constructors
		public ChannelEnablingChangeMessage() { }

		public ChannelEnablingChangeMessage(uint channel = 0, bool enable = false)
		{
			Channel = channel;
			Enable = enable;
		}

	}
}
