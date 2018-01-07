using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class NotificationUpdateFlagMessage : Message
	{

		// Properties
		public uint Index { get; set; }


		// Constructors
		public NotificationUpdateFlagMessage() { }

		public NotificationUpdateFlagMessage(uint index = 0)
		{
			Index = index;
		}

	}
}
