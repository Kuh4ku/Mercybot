using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class EmoteListMessage : Message
	{

		// Properties
		public List<uint> EmoteIds { get; set; }


		// Constructors
		public EmoteListMessage() { }

		public EmoteListMessage(List<uint> emoteIds = null)
		{
			EmoteIds = emoteIds;
		}

	}
}
