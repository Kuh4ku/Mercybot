using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class EnabledChannelsMessage : Message
	{

		// Properties
		public List<uint> Channels { get; set; }
		public List<uint> Disallowed { get; set; }


		// Constructors
		public EnabledChannelsMessage() { }

		public EnabledChannelsMessage(List<uint> channels = null, List<uint> disallowed = null)
		{
			Channels = channels;
			Disallowed = disallowed;
		}

	}
}
