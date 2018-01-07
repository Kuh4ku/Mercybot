using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class BasicDateMessage : Message
	{

		// Properties
		public uint Day { get; set; }
		public uint Month { get; set; }
		public uint Year { get; set; }


		// Constructors
		public BasicDateMessage() { }

		public BasicDateMessage(uint day = 0, uint month = 0, uint year = 0)
		{
			Day = day;
			Month = month;
			Year = year;
		}

	}
}
