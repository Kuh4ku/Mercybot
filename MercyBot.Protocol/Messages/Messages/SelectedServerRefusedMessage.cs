using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class SelectedServerRefusedMessage : Message
	{

		// Properties
		public int ServerId { get; set; }
		public uint Error { get; set; }
		public uint ServerStatus { get; set; }


		// Constructors
		public SelectedServerRefusedMessage() { }

		public SelectedServerRefusedMessage(int serverId = 0, uint error = 1, uint serverStatus = 1)
		{
			ServerId = serverId;
			Error = error;
			ServerStatus = serverStatus;
		}

	}
}
