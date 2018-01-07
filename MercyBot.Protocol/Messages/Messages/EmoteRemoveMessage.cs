using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class EmoteRemoveMessage : Message
	{

		// Properties
		public uint EmoteId { get; set; }


		// Constructors
		public EmoteRemoveMessage() { }

		public EmoteRemoveMessage(uint emoteId = 0)
		{
			EmoteId = emoteId;
		}

	}
}
