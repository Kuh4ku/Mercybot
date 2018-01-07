using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class PartsListMessage : Message
	{

		// Properties
		public List<ContentPart> Parts { get; set; }


		// Constructors
		public PartsListMessage() { }

		public PartsListMessage(List<ContentPart> parts = null)
		{
			Parts = parts;
		}

	}
}
