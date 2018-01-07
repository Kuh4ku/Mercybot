using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class DocumentReadingBeginMessage : Message
	{

		// Properties
		public uint DocumentId { get; set; }


		// Constructors
		public DocumentReadingBeginMessage() { }

		public DocumentReadingBeginMessage(uint documentId = 0)
		{
			DocumentId = documentId;
		}

	}
}
