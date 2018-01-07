using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class TeleportBuddiesAnswerMessage : Message
	{

		// Properties
		public bool Accept { get; set; }


		// Constructors
		public TeleportBuddiesAnswerMessage() { }

		public TeleportBuddiesAnswerMessage(bool accept = false)
		{
			Accept = accept;
		}

	}
}
