using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class StatedElementUpdatedMessage : Message
	{

		// Properties
		public StatedElement StatedElement { get; set; }


		// Constructors
		public StatedElementUpdatedMessage() { }

		public StatedElementUpdatedMessage(StatedElement statedElement = null)
		{
			StatedElement = statedElement;
		}

	}
}
