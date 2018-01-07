using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildPaddockTeleportRequestMessage : Message
	{

		// Properties
		public int PaddockId { get; set; }


		// Constructors
		public GuildPaddockTeleportRequestMessage() { }

		public GuildPaddockTeleportRequestMessage(int paddockId = 0)
		{
			PaddockId = paddockId;
		}

	}
}
