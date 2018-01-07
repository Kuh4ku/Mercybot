using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class ServersListMessage : Message
	{

		// Properties
		public List<GameServerInformations> Servers { get; set; }


		// Constructors
		public ServersListMessage() { }

		public ServersListMessage(List<GameServerInformations> servers = null)
		{
			Servers = servers;
		}

	}
}
