using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class NewMailMessage : MailStatusMessage
	{

		// Properties
		public List<uint> SendersAccountId { get; set; }


		// Constructors
		public NewMailMessage() { }

		public NewMailMessage(uint unread = 0, uint total = 0, List<uint> sendersAccountId = null)
		{
			Unread = unread;
			Total = total;
			SendersAccountId = sendersAccountId;
		}

	}
}
