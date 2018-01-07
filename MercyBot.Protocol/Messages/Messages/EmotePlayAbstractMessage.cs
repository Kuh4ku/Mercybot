using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class EmotePlayAbstractMessage : Message
	{

		// Properties
		public uint EmoteId { get; set; }
		public double EmoteStartTime { get; set; }


		// Constructors
		public EmotePlayAbstractMessage() { }

		public EmotePlayAbstractMessage(uint emoteId = 0, double emoteStartTime = 0)
		{
			EmoteId = emoteId;
			EmoteStartTime = emoteStartTime;
		}

	}
}
