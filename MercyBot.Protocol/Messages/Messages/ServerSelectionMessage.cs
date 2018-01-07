using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ServerSelectionMessage : Message
	{

		// Properties
		public int ServerId { get; set; }


		// Constructors
		public ServerSelectionMessage() { }

		public ServerSelectionMessage(int serverId = 0)
		{
			ServerId = serverId;
		}

	}
}
