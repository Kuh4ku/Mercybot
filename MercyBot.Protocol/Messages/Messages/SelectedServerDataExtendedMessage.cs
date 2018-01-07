using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class SelectedServerDataExtendedMessage : SelectedServerDataMessage
	{

		// Properties
		public List<uint> ServerIds { get; set; }


		// Constructors
		public SelectedServerDataExtendedMessage() { }

		public SelectedServerDataExtendedMessage(int serverId = 0, string address = "", uint port = 0, bool canCreateNewCharacter = false, string ticket = "", List<uint> serverIds = null)
		{
			ServerId = serverId;
			Address = address;
			Port = port;
			CanCreateNewCharacter = canCreateNewCharacter;
			Ticket = ticket;
			ServerIds = serverIds;
		}

	}
}
