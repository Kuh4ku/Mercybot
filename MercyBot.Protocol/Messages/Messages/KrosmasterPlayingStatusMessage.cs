using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class KrosmasterPlayingStatusMessage : Message
	{

		// Properties
		public bool Playing { get; set; }


		// Constructors
		public KrosmasterPlayingStatusMessage() { }

		public KrosmasterPlayingStatusMessage(bool playing = false)
		{
			Playing = playing;
		}

	}
}
