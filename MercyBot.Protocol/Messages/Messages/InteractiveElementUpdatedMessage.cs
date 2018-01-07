using System.Collections.Generic;
using MercyBot.Protocol.Types;

namespace MercyBot.Protocol.Messages
{
	public class InteractiveElementUpdatedMessage : Message
	{

		// Properties
		public InteractiveElement InteractiveElement { get; set; }


		// Constructors
		public InteractiveElementUpdatedMessage() { }

		public InteractiveElementUpdatedMessage(InteractiveElement interactiveElement = null)
		{
			InteractiveElement = interactiveElement;
		}

	}
}
