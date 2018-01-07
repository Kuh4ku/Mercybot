using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class AccountLoggingKickedMessage : Message
	{

		// Properties
		public uint Days { get; set; }
		public uint Hours { get; set; }
		public uint Minutes { get; set; }


		// Constructors
		public AccountLoggingKickedMessage() { }

		public AccountLoggingKickedMessage(uint days = 0, uint hours = 0, uint minutes = 0)
		{
			Days = days;
			Hours = hours;
			Minutes = minutes;
		}

	}
}
