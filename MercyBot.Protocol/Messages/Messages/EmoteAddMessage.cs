using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class EmoteAddMessage : Message
	{

		// Properties
		public uint EmoteId { get; set; }


		// Constructors
		public EmoteAddMessage() { }

		public EmoteAddMessage(uint emoteId = 0)
		{
			EmoteId = emoteId;
		}

	}
}
