using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class SequenceEndMessage : Message
	{

		// Properties
		public uint ActionId { get; set; }
		public int AuthorId { get; set; }
		public int SequenceType { get; set; }


		// Constructors
		public SequenceEndMessage() { }

		public SequenceEndMessage(uint actionId = 0, int authorId = 0, int sequenceType = 0)
		{
			ActionId = actionId;
			AuthorId = authorId;
			SequenceType = sequenceType;
		}

	}
}
