using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class GuildModificationStartedMessage : Message
	{

		// Properties
		public bool CanChangeName { get; set; }
		public bool CanChangeEmblem { get; set; }


		// Constructors
		public GuildModificationStartedMessage() { }

		public GuildModificationStartedMessage(bool canChangeName = false, bool canChangeEmblem = false)
		{
			CanChangeName = canChangeName;
			CanChangeEmblem = canChangeEmblem;
		}

	}
}
