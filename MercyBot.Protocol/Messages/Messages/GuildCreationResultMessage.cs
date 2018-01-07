using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildCreationResultMessage : Message
	{

		// Properties
		public uint Result { get; set; }


		// Constructors
		public GuildCreationResultMessage() { }

		public GuildCreationResultMessage(uint result = 0)
		{
			Result = result;
		}

	}
}
