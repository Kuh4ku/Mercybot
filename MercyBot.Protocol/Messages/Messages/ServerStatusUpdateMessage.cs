using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ServerStatusUpdateMessage : Message
	{

		// Properties
		public GameServerInformations Server { get; set; }


		// Constructors
		public ServerStatusUpdateMessage() { }

		public ServerStatusUpdateMessage(GameServerInformations server = null)
		{
			Server = server;
		}

	}
}
