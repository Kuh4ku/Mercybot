using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class NotificationListMessage : Message
	{

		// Properties
		public List<int> Flags { get; set; }


		// Constructors
		public NotificationListMessage() { }

		public NotificationListMessage(List<int> flags = null)
		{
			Flags = flags;
		}

	}
}
