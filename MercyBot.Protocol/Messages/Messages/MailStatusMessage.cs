using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class MailStatusMessage : Message
	{

		// Properties
		public uint Unread { get; set; }
		public uint Total { get; set; }


		// Constructors
		public MailStatusMessage() { }

		public MailStatusMessage(uint unread = 0, uint total = 0)
		{
			Unread = unread;
			Total = total;
		}

	}
}
