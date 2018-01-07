using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class SequenceNumberMessage : Message
	{

		// Properties
		public uint Number { get; set; }


		// Constructors
		public SequenceNumberMessage() { }

		public SequenceNumberMessage(uint number = 0)
		{
			Number = number;
		}

	}
}
