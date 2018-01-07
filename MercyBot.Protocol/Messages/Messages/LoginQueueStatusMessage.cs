using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class LoginQueueStatusMessage : Message
	{

		// Properties
		public uint Position { get; set; }
		public uint Total { get; set; }


		// Constructors
		public LoginQueueStatusMessage() { }

		public LoginQueueStatusMessage(uint position = 0, uint total = 0)
		{
			Position = position;
			Total = total;
		}

	}
}
