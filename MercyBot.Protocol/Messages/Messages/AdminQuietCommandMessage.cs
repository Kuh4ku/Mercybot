using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AdminQuietCommandMessage : AdminCommandMessage
	{

		// Constructors
		public AdminQuietCommandMessage() { }

		public AdminQuietCommandMessage(string content = "")
		{
			Content = content;
		}

	}
}
