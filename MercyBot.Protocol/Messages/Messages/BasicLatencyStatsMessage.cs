using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class BasicLatencyStatsMessage : Message
	{

		// Properties
		public uint Latency { get; set; }
		public uint SampleCount { get; set; }
		public uint Max { get; set; }


		// Constructors
		public BasicLatencyStatsMessage() { }

		public BasicLatencyStatsMessage(uint latency = 0, uint sampleCount = 0, uint max = 0)
		{
			Latency = latency;
			SampleCount = sampleCount;
			Max = max;
		}

	}
}
