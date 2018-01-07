using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildPaddockRemovedMessage : Message
	{

		// Properties
		public int PaddockId { get; set; }


		// Constructors
		public GuildPaddockRemovedMessage() { }

		public GuildPaddockRemovedMessage(int paddockId = 0)
		{
			PaddockId = paddockId;
		}

	}
}
