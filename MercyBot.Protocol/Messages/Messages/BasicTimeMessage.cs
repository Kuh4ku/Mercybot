using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class BasicTimeMessage : Message
	{

		// Properties
		public uint Timestamp { get; set; }
		public int TimezoneOffset { get; set; }


		// Constructors
		public BasicTimeMessage() { }

		public BasicTimeMessage(uint timestamp = 0, int timezoneOffset = 0)
		{
			Timestamp = timestamp;
			TimezoneOffset = timezoneOffset;
		}

	}
}
